using AutoMapper;
using AutoMapper.QueryableExtensions;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Domain.Tickets;
using EventPlatform.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventPlatform.Application.Features.Tickets.Query.GetIfAvailable
{
    public class GetTicketIfAvailableHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetTicketIfAvailableQuery, Result<TicketDto>>
    {
        public async Task<Result<TicketDto>> Handle(GetTicketIfAvailableQuery request, CancellationToken cancellationToken)
        {
            var ticket = await context.Tickets
                .Where(t => t.Id == request.Id && t.Event.Status == EventStatus.Approved)
                .ProjectTo<TicketDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            return ticket is null ? Result.Failure<TicketDto>("Ticket not available", Status.Forbiden)
                : Result.Success(ticket);
        }
    }
}
