using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Notifications;
using MediatR;

namespace EventPlatform.Application.Features.Notifications.Command.UpdateById
{
    public class UpdateNotificationByIdCommand : IRequest<Result<NotificationDto>>, ICacheInvalidate
    {
        public Guid Id { get; set; }

        public NotificationUpdateDto Entity { get; set; }

        public string[] CacheKeys => [$"event:{Id}", "events*"];
    }
}
