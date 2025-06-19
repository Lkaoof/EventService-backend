using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.UserTickets.Command.DeleteById
{
    public class DeleteUserTicketHandler(IActions actions) : IRequestHandler<DeleteUserTicketCommand, Result>
    {
        public async Task<Result> Handle(DeleteUserTicketCommand request, CancellationToken cancellationToken)
        {
            return await actions.DeleteById<UserTicket>(request.Id, cancellationToken);
        }
    }
}
