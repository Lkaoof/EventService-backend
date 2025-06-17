using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Application.Models.Domain.EventMoods;
using MediatR;

namespace EventPlatform.Application.Features.EventMoods.Query.GetAsPage
{
    public class GetEventMoodsAsPageQuery : IRequest<Page<EventMoodDto>>, ICacheable
    {
        public Pageable Page { get; set; }
        public string CacheKey => $"event_moods:page:{Page.Index},{Page.Size}";
    }
}
