using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Models.Domain.Notifications;
using MediatR;

namespace EventPlatform.Application.Features.Notifications.Query.Get
{
    public class GetNotificationsQuery : IRequest<ICollection<NotificationDto>>, ICacheable
    {
        public string CacheKey => $"notifications";
    }
}
