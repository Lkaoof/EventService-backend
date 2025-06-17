using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.Mapping;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.UserTickets;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.UserTickets.Command.Create
{
    public class CreateUserTicketCommand : IRequest<Result<UserTicketDto>>, ICacheInvalidate, IMapWith<UserTicket>
    {
        public decimal Price { get; set; }
        public Guid TicketId { get; set; }
        public Guid UserId { get; set; }

        public string[] CacheKeys => ["user_tickets*"];
    }
}
