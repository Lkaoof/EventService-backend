using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.EventMoods;
using MediatR;

namespace EventPlatform.Application.Features.EventMoods.Query.GetById
{
    public class GetEventMoodByIdQuery : IRequest<Result<EventMoodDto>>, ICacheable
    {
        public Guid Id { get; set; }
        public string CacheKey => $"event_mood:{Id}";
    }
}
