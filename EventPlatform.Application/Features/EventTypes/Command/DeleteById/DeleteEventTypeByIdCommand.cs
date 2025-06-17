using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using MediatR;

namespace EventPlatform.Application.Features.EventTypes.Command.DeleteById
{
    public class DeleteEventTypeByIdCommand : IRequest<Result>, ICacheInvalidate
    {
        public Guid Id { get; set; }

        public string[] CacheKeys => [$"eventType:{Id}", "eventTypes*"];
    }
}
