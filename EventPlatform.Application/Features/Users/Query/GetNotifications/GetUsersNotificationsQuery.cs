using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Models.Domain.Notifications;
using MediatR;

namespace EventPlatform.Application.Features.Users.Query.GetNotifications
{
    public class GetUsersNotificationsQuery : IRequest<ICollection<UserNotificationDto>>, ICacheable
    {
        public Guid UserId { get; set; }
        public string CacheKey => $"user:{UserId}:notifications";
    }
}
