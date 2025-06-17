using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.UserTickets;
using MediatR;

namespace EventPlatform.Application.Features.UserTickets.Query.GetById
{
    public class GetUserTicketByIdQuery : IRequest<Result<UserTicketDto>>, ICacheable
    {
        public Guid Id { get; set; }

        public string CacheKey => $"user_ticket:{Id}";
    }
}
