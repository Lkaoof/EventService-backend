using EventPlatform.Application.Features.Events.Command.ApproveEvent;
using EventPlatform.Application.Features.Events.Command.RejectEvent;
using EventPlatform.Application.Features.Events.Query.GetById;
using EventPlatform.Application.Features.Events.Query.GetModeratedEvents;
using EventPlatform.Application.Features.Events.Query.GetRejectedEvents;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.WebApi.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPlatform.WebApi.Controllers.Moderator
{
    [Tags("Moderation")]
    [Authorize(Roles = "Admin, Moderator")]
    [ApiController]
    [Route("/moderation")]
    public class ModerationController(IMediator mediator, IEmailSender email) : ControllerApiBase
    {
        [HttpGet("moderated-events")]
        public async Task<IActionResult> GetModeratedEvents([FromQuery] Pageable page, CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetModerateEventsAsPageQuery() { Page = page }, ct));
        }

        [HttpGet("rejected-events")]
        public async Task<IActionResult> GetRejectedEvents([FromQuery] Pageable page, CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetRejectedEventsQuery() { Page = page }, ct));
        }

        [HttpPost("events/{eventId}/approve")]
        public async Task<IActionResult> ApproveEvent(Guid eventId, CancellationToken ct)
        {
            var approve = await mediator.Send(new ApproveEventCommand() { EventId = eventId });
            if (approve.IsFailure) return ToActionResult(approve);

            var eventResult = await mediator.Send(new GetEventByIdQuery() { Id = eventId });
            if (eventResult.IsFailure) return ToActionResult(eventResult);
            var event_ = eventResult.Value!;

            await email.SendAsync(event_.Creator.Email, "Оповещение модерации", $"Ваше событие '{event_.Title}' успешно прошло модерацию", ct);

            return ToActionResult(approve);
        }

        [HttpPost("events/{eventId}/reject")]
        public async Task<IActionResult> RejectEvent(Guid eventId, string comment, CancellationToken ct)
        {
            var reject = await mediator.Send(new RejectEventCommand() { EventId = eventId });
            if (reject.IsFailure) return ToActionResult(reject);

            var eventResult = await mediator.Send(new GetEventByIdQuery() { Id = eventId });
            if (eventResult.IsFailure) return ToActionResult(eventResult);
            var event_ = eventResult.Value!;

            await email.SendAsync(event_.Creator.Email, "Оповещение модерации", $"Ваше событие '{event_.Title}' было отклонено модерацией по причине: ${comment}", ct);

            return ToActionResult(await mediator.Send(new RejectEventCommand() { EventId = eventId }));
        }
    }
}
