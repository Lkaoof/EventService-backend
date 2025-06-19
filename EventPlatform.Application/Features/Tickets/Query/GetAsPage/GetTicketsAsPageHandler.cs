using AutoMapper;
using AutoMapper.QueryableExtensions;
using EventPlatform.Application.Extentions;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Application.Models.Domain.Tickets;
using MediatR;

namespace EventPlatform.Application.Features.Tickets.Query.GetAsPage
{
    public class GetTicketsAsPageHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetTicketsAsPageQuery, Page<TicketDto>>
    {
        public async Task<Page<TicketDto>> Handle(GetTicketsAsPageQuery request, CancellationToken cancellationToken)
        {
            return await context.Tickets.ProjectTo<TicketDto>(mapper.ConfigurationProvider).PaginateAsync(request.Page, cancellationToken);
        }
    }
}
