using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Notifications;
using MediatR;

namespace EventPlatform.Application.Features.Notifications.Query.GetById
{
    public class GetNotificationByIdQuery : IRequest<Result<NotificationDto>>, ICacheable
    {
        public Guid Id { get; set; }

        public string CacheKey => $"notification:{Id}";
    }
}
