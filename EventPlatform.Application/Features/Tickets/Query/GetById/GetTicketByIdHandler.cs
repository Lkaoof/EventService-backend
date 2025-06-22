using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.Tickets;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Tickets.Query.GetById
{
    public class GetTicketByIdHandler(IActions actions) : IRequestHandler<GetTicketByIdQuery, Result<TicketDto>>
    {
        public async Task<Result<TicketDto>> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetById<Ticket, TicketDto>(request.Id, cancellationToken);
        }
    }
}
