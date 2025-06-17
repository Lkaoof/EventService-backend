using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.EventTypes;
using MediatR;

namespace EventPlatform.Application.Features.EventTypes.Command.UpdateById
{
    public class UpdateEventTypeByIdCommand : IRequest<Result<EventTypeDto>>, ICacheInvalidate
    {
        public Guid Id { get; set; }

        public EventTypeUpdateDto Entity { get; set; }

        public string[] CacheKeys => [$"eventType:{Id}", "eventTypes*"];
    }
}
