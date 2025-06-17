using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.UserTickets;
using MediatR;

namespace EventPlatform.Application.Features.UserTickets.Command.UpdateById
{
    public class UpdateUserTicketCommand : IRequest<Result<UserTicketDto>>, ICacheInvalidate
    {
        public Guid Id { get; set; }

        public UserTicketUpdateDto Entity { get; set; }
        public string[] CacheKeys => [$"user_ticket:{Id}", "user_tickets*"];
    }
}
