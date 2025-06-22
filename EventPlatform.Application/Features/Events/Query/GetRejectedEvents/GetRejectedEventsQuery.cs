using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Application.Models.Domain.Events;
using MediatR;

namespace EventPlatform.Application.Features.Events.Query.GetRejectedEvents
{
    public class GetRejectedEventsQuery : IRequest<Page<EventDto>>, ICacheable
    {
        public Pageable Page { get; set; }
        public string CacheKey => $"events:page:{Page.Index},{Page.Size}:rejected";
    }
}
