using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.EventMoods;
using MediatR;

namespace EventPlatform.Application.Features.EventMoods.Command.UpdateById
{
    public class UpdateEventMoodByIdCommand : IRequest<Result<EventMoodDto>>, ICacheInvalidate
    {
        public Guid Id { get; set; }

        public EventMoodUpdateDto Entity { get; set; }

        public string[] CacheKeys => [$"event_mood:{Id}", "event_moods*"];
    }
}
