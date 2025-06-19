using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.UserTickets;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.UserTickets.Command.UpdateById
{
    public class UpdateUserTicketHandler(IActions actions) : IRequestHandler<UpdateUserTicketCommand, Result<UserTicketDto>>
    {
        public async Task<Result<UserTicketDto>> Handle(UpdateUserTicketCommand request, CancellationToken cancellationToken)
        {
            return await actions.Update<UserTicket, UserTicketDto>(request.Id, request.Entity, cancellationToken);
        }
    }
}
