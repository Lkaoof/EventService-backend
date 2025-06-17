using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Features.Notifications.Command.UpdateById
{
    public class NotificationUpdateDto : IMapWith<Notification>
    {
        public string? Subject { get; set; }

        public string? Content { get; set; }

        public NotificationType? Type { get; set; }
    }
}
