using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Application.Models.Domain.EventTypes;
using MediatR;

namespace EventPlatform.Application.Features.EventTypes.Query.GetAsPage
{
    public class GetEventTypeAsPageQuery : IRequest<Page<EventTypeDto>>, ICacheable
    {
        public Pageable Page { get; set; }
        public string CacheKey => $"event_types:page:{Page.Index},{Page.Size}";
    }
}
