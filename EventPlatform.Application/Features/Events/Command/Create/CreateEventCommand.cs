using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Events;
using MediatR;

namespace EventPlatform.Application.Features.Events.Command.Create
{
    public class CreateEventCommand : IRequest<Result<EventDto>>, ICacheInvalidate
    {
        public EventCreateDto Entity { get; set; }

        public string[] CacheKeys => ["events*"];
    }
}
