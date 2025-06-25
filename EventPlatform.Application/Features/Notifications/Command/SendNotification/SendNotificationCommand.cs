using EventPlatform.Application.Models.Domain.Notifications;
using MediatR;

namespace EventPlatform.Application.Features.Notifications.Command.SendNotification
{
    public class SendNotificationCommand : IRequest
    {
        public Guid UserId { get; set; }

        public NotificationDto Notification { get; set; }
    }
}
