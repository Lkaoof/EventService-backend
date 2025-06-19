using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Models.Domain.UserTickets;
using MediatR;

namespace EventPlatform.Application.Features.Users.Query.GetTickets
{
    public class GetUsersTicketsQuery : IRequest<ICollection<UserTicketDto>>, ICacheable
    {
        public Guid UserId { get; set; }
        public string CacheKey => $"user:{UserId}:tickets";
    }
}
