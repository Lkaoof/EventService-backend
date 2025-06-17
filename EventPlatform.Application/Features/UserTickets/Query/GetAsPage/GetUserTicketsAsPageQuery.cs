using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Application.Models.Domain.UserTickets;
using MediatR;

namespace EventPlatform.Application.Features.UserTickets.Query.GetAsPage
{
    public class GetUserTicketsAsPageQuery : IRequest<Page<UserTicketDto>>, ICacheable
    {
        public Pageable Page { get; set; }
        public string CacheKey => $"user_tickets:page:{Page.Index},{Page.Size}";
    }
}
