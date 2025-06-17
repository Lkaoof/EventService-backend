using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Models.Domain.Tickets;
using MediatR;

namespace EventPlatform.Application.Features.Tickets.Query.Get
{
    public class GetTicketsQuery : IRequest<ICollection<TicketDto>>, ICacheable
    {
        public string CacheKey => $"events";
    }
}
