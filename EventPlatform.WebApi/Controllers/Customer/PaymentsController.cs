using EventPlatform.WebApi.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPlatform.WebApi.Controllers.Customer
{
    [Authorize]
    //[Tags("Customer")]
    [ApiController]
    [Route("/payments")]
    public class PaymentsController(IMediator mediator) : ControllerApiBase
    {
        // TODO: Персональная история платежей

        [HttpPost("buy")]
        public async Task<IActionResult> Buy(Guid ticketId, CancellationToken ct)
        {
            // Профиль пользователя: email, name, birthdate, avatar, phonenumber, edit_date,
            return Ok();
        }

        [HttpPost("return")]
        public async Task<IActionResult> Return(Guid ticketId, CancellationToken ct)
        {
            // Профиль пользователя: email, name, birthdate, avatar, phonenumber, edit_date,
            return Ok();
        }
    }
}
