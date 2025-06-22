using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using MediatR;

namespace EventPlatform.Application.Features.Tickets.Command.DecreaseAvailableCount
{
    public class DecreaseTicketAvailableCountCommand : IRequest<Result>, ICacheInvalidate
    {
        public Guid Id { get; set; }
        public string[] CacheKeys => [$"ticket:{Id},", "tickets*"];
    }
}
