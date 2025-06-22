using EventPlatform.Application.Features.Auth.Query.GetIdentityById;
using EventPlatform.Application.Features.Events.Query.GetById;
using EventPlatform.Application.Features.Purchases.Command.Create;
using EventPlatform.Application.Features.Tickets.Command.DecreaseAvailableCount;
using EventPlatform.Application.Features.UserTickets.Command.Create;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Application.Payment;
using EventPlatform.Application.Models.Application.Payment.Response;
using EventPlatform.Application.Models.Domain.Purchases;
using EventPlatform.Application.Models.Domain.UserTickets;
using EventPlatform.WebApi.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPlatform.WebApi.Controllers.Payment
{
    [Authorize]
    //[Tags("Customer")]
    [ApiController]
    [Route("/api/payment-confirm")]
    public class PaymentsController(IMediator mediator, IPaymentsProvider payments, ICache cache, IJobScheduler jobs) : ControllerApiBase
    {
        // 5. Получить ответ от сервиса платежей о статусе платежа.
        // 6. Если платеж прошел, сохранить покупку пользователя в postgres 
        // 7. Запланировать напоминание на почту за 24 до начала мероприятия
        [HttpPost()]
        public async Task<IActionResult> ConfirmPayment([FromQuery] string orderId, CancellationToken ct)
        {
            // Ответ от сервиса обработки платежей
            var response = new PaymentCompleteResponse()
            {
                Id = orderId,
                Event = "payment.succeeded",
                Url = $"http://localhost:5091/api/purchases",
            };

            var payment = await cache.ObjectGetAsync<TicketPendingPayment>($"pending_payment:{response.Id}", ct);
            if (payment == null) return BadRequest(response.Id);
            await cache.RemoveAsync($"pending_payment:{response.Id}", ct);
            await mediator.Send(new DecreaseTicketAvailableCountCommand() { Id = payment.TicketId });

            var purchase = await mediator.Send(new CreatePurchaseCommand()
            {
                Entity = new PurchaseCreateDto
                {
                    Amount = payment.Amount,
                    BillUrl = "",
                    Status = Domain.Models.PurchaseStatus.Success,
                    CustomerId = payment.UserId,
                    Date = DateTime.UtcNow,
                    ProductUrl = $"tickets/{payment.TicketId}",
                    Description = $"Покупка билета",
                }
            }, ct);
            if (purchase.IsFailure) return Problem($"Failed to process purchase of ticket");

            var userTicket = await mediator.Send(new CreateUserTicketCommand()
            {
                Entity = new UserTicketCreateDto
                {
                    UserId = payment.UserId,
                    TicketId = payment.TicketId
                }
            });
            if (userTicket.IsFailure) return Problem($"Failed to add user ticket");

            var eventResult = await mediator.Send(new GetEventByIdQuery() { Id = payment.EventId }, ct);
            var userResult = await mediator.Send(new GetIdentityByIdQuery() { Id = payment.UserId }, ct);
            var event_ = eventResult.Value!;
            var user = userResult.Value!;

            await jobs.ScheduleEventEmailReminder(event_.StartAt.AddHours(-24), user.Email, payment.EventId, ct);

            return ToActionResult(purchase);
        }
    }
}
