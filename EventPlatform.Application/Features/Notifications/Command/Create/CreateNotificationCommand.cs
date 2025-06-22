using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Notifications;
using MediatR;

namespace EventPlatform.Application.Features.Notifications.Command.Create
{
    public class CreateNotificationCommand : IRequest<Result<NotificationDto>>, ICacheInvalidate
    {
        public NotificationCreateDto Entity { get; set; }

        public string[] CacheKeys => ["notifications*"];
    }
}
