using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.Mapping;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Notifications;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Notifications.Command.Create
{
    public class CreateNotificationCommand : IRequest<Result<NotificationDto>>, ICacheInvalidate, IMapWith<Notification>
    {
        public string Subject { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public NotificationType Type { get; set; }

        public string[] CacheKeys => ["notifications*"];
    }
}
