using EventPlatform.WebApi.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPlatform.WebApi.Controllers.Moderator
{
    [Tags("Moderation")]
    [Authorize(Roles ="Admin, Moderator")]
    [ApiController]
    [Route("/moderation")]
    public class ModerationController(IMediator mediator) : ControllerApiBase
    {
        [HttpGet("events")]
        public async Task<IActionResult> GetEvents(CancellationToken ct)
        {
            // Получение ивентов на модерации
            return Ok();
        }

        [HttpPost("events/{eventId}/approve")]
        public async Task<IActionResult> ApproveEvent(Guid eventId, CancellationToken ct)
        {
            // Подтверждение прохождения модерации ивента
            return Ok();
        }

        [HttpPost("events/{eventId}/reject")]
        public async Task<IActionResult> RejectEvent(Guid eventId, CancellationToken ct)
        {
            // Подтверждение прохождения модерации ивента
            return Ok();
        }
    }
}
