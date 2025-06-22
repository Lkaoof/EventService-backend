using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.UserTickets;
using MediatR;

namespace EventPlatform.Application.Features.UserTickets.Command.Create
{
    public class CreateUserTicketCommand : IRequest<Result<UserTicketDto>>, ICacheInvalidate
    {
        public UserTicketCreateDto Entity { get; set; }

        public string[] CacheKeys => ["user_tickets*"];
    }
}
