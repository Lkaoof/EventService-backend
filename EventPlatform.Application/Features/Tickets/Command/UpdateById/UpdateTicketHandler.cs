using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.Tickets;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Tickets.Command.UpdateById
{
    public class UpdateTicketHandler(IActions actions) : IRequestHandler<UpdateTicketCommand, Result<TicketDto>>
    {
        public async Task<Result<TicketDto>> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            return await actions.Update<Ticket, TicketDto>(request.Id, request.Entity, cancellationToken);
        }
    }
}
