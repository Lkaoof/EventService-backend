using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.Notifications
{
    public class NotificationCreateDto : IMapWith<Notification>
    {
        public string Subject { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public NotificationType Type { get; set; }

        public Guid UserId { get; set; }
    }
}
