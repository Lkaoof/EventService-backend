﻿using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.Tickets;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Tickets.Command.Create
{
    public class CreateTicketHandler(IActions actions) : IRequestHandler<CreateTicketCommand, Result<TicketDto>>
    {
        public async Task<Result<TicketDto>> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            return await actions.Create<Ticket, TicketDto>(request.Entity, cancellationToken, async (ticket, _) => ticket.EventId = request.EventId);
        }
    }
}
