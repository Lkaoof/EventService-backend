using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Events;
using MediatR;

namespace EventPlatform.Application.Features.Events.Command.UpdateEventById
{
    public class UpdateEventByIdCommand : IRequest<Result<EventDto>>, ICacheInvalidate
    {
        public Guid Id { get; set; }

        public EventUpdateDto Event { get; set; }

        public string[] CacheKeys => [$"event:{Id}", "events*"];
    }
}
