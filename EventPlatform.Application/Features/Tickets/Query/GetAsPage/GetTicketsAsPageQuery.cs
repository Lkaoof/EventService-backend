using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Application.Models.Domain.Tickets;
using MediatR;

namespace EventPlatform.Application.Features.Tickets.Query.GetAsPage
{
    public class GetTicketsAsPageQuery : IRequest<Page<TicketDto>>, ICacheable
    {
        public Pageable Page { get; set; }
        public string CacheKey => $"tickets:page:{Page.Index},{Page.Size}";
    }
}
