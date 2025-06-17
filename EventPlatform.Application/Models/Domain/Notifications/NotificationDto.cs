using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.Notifications
{
    public class NotificationDto : IMapWith<Notification>
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Type { get; set; } = null!;
        public Guid UserId { get; set; }
    }
}
