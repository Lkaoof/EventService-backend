using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using MediatR;

namespace EventPlatform.Application.Features.EventMoods.Command.DeleteById
{
    public class DeleteEventMoodByIdCommand : IRequest<Result>, ICacheInvalidate
    {
        public Guid Id { get; set; }
        public string[] CacheKeys => [$"event_mood:{Id}", "event_moods*"];
    }
}
