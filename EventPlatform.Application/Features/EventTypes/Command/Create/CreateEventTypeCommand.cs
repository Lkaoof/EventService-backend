using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.EventTypes;
using MediatR;

namespace EventPlatform.Application.Features.EventTypes.Command.Create
{
    public class CreateEventTypeCommand : IRequest<Result<EventTypeDto>>, ICacheInvalidate
    {
        public EventTypeCreateDto Entity { get; set; }

        public string[] CacheKeys => ["eventTypes*"];
    }
}
