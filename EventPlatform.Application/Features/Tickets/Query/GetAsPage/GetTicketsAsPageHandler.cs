using AutoMapper;
using EventPlatform.Application.Extentions;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Application.Models.Domain.Tickets;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Tickets.Query.GetAsPage
{
    public class GetTicketsAsPageHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetTicketsAsPageQuery, Page<TicketDto>>
    {
        public async Task<Page<TicketDto>> Handle(GetTicketsAsPageQuery request, CancellationToken cancellationToken)
        {
            return await context.Tickets.AsQueryable().PaginateAsync<Ticket, TicketDto>(request.Page, mapper, cancellationToken);

        }
    }
}
