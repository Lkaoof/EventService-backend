using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Models.Domain.EventMoods;
using MediatR;

namespace EventPlatform.Application.Features.EventMoods.Query.Get
{
    public class GetEventMoodsQuery : IRequest<ICollection<EventMoodDto>>, ICacheable
    {
        public string CacheKey => $"event_moods";
    }
}
