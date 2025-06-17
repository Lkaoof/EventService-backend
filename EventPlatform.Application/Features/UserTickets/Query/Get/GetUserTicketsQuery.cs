using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Models.Domain.UserTickets;
using MediatR;

namespace EventPlatform.Application.Features.UserTickets.Query.Get
{
    public class GetUserTicketsQuery : IRequest<ICollection<UserTicketDto>>, ICacheable
    {
        public string CacheKey => $"user_tickets";
    }
}
