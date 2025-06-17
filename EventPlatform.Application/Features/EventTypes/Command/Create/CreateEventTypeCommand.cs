using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.Mapping;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.EventTypes;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.EventTypes.Command.Create
{
    public class CreateEventTypeCommand : IRequest<Result<EventTypeDto>>, ICacheInvalidate, IMapWith<EventType>
    {
        public string Title { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true;

        public string[] CacheKeys => ["eventTypes*"];
    }
}
