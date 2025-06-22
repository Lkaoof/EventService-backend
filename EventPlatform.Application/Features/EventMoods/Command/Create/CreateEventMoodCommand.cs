using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.EventMoods;
using MediatR;

namespace EventPlatform.Application.Features.EventMoods.Command.Create
{
    public class CreateEventMoodCommand : IRequest<Result<EventMoodDto>>, ICacheInvalidate
    {
        public EventMoodCreateDto Entity { get; set; }
        public string[] CacheKeys => ["event_moods*"];
    }
}
