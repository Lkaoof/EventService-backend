using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Tickets;
using MediatR;

namespace EventPlatform.Application.Features.Tickets.Query.GetIfAvailable
{
    public class GetTicketIfAvailableQuery : IRequest<Result<TicketDto>>, ICacheable
    {
        public Guid Id { get; set; }
        public string CacheKey => $"ticket:{Id}";
    }
}
