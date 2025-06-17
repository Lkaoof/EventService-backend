using AutoMapper;
using EventPlatform.Application.Extentions;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Application.Models.Domain.UserTickets;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.UserTickets.Query.GetAsPage
{
    public class GetUserTicketsAsPageHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetUserTicketsAsPageQuery, Page<UserTicketDto>>
    {
        public async Task<Page<UserTicketDto>> Handle(GetUserTicketsAsPageQuery request, CancellationToken cancellationToken)
        {
            return await context.UsersTickets.AsQueryable().PaginateAsync<UserTicket, UserTicketDto>(request.Page, mapper, cancellationToken);
        }
    }
}
