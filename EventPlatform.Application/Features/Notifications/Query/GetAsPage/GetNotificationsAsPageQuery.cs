using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Application.Models.Domain.Notifications;
using MediatR;

namespace EventPlatform.Application.Features.Notifications.Query.GetAsPage
{
    public class GetNotificationsAsPageQuery : IRequest<Page<NotificationDto>>, ICacheable
    {
        public Pageable Page { get; set; }
        public string CacheKey => $"notifications:page:{Page.Index},{Page.Size}";
    }
}
