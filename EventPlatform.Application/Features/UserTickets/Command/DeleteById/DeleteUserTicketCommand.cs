using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using MediatR;

namespace EventPlatform.Application.Features.UserTickets.Command.DeleteById
{
    public class DeleteUserTicketCommand : IRequest<Result>, ICacheInvalidate
    {
        public Guid Id { get; set; }
        public string[] CacheKeys => [$"user_ticket:{Id}", "user_tickets*"];
    }
}
