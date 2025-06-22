using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using MediatR;

namespace EventPlatform.Application.Features.Events.Command.ApproveEvent
{
    public class ApproveEventCommand : IRequest<Result>, ICacheInvalidate
    {
        public Guid EventId { get; set; }
        public string[] CacheKeys => [$"event:{EventId}", $"events*"];
    }
}
