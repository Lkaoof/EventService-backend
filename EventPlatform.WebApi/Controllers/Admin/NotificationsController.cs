using AutoMapper;
using EventPlatform.Application.Features.Notifications.Command.Create;
using EventPlatform.Application.Features.Notifications.Command.SendNotification;
using EventPlatform.Application.Models.Domain.Notifications;
using EventPlatform.WebApi.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPlatform.WebApi.Controllers.Admin
{
    [Tags("Admin")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("/api/notifications")]
    public class NotificationsController(IMediator mediator) : ControllerApiBase
    {
        [HttpPost]
        public async Task<IActionResult> SendTest(NotificationCreateDto notification, IMapper mapper, CancellationToken ct)
        {
            var createResult = await mediator.Send(new CreateNotificationCommand { Entity = notification }, ct);
            if (createResult.IsFailure) return ToActionResult(createResult);

            var notificationDto = createResult.Value!;
            await mediator.Send(new SendNotificationCommand { Notification = notificationDto }, ct);

            return Ok();
        }
    }
}
