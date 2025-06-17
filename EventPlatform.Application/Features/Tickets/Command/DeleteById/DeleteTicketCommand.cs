using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using MediatR;

namespace EventPlatform.Application.Features.Tickets.Command.DeleteById
{
    public class DeleteTicketCommand : IRequest<Result>, ICacheInvalidate
    {
        public Guid Id { get; set; }
        public string[] CacheKeys => [$"ticket:{Id}", "tickets*"];
    }
}
