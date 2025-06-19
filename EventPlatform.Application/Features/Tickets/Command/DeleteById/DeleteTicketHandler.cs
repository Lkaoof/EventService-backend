using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Tickets.Command.DeleteById
{
    public class DeleteTicketHandler(IActions actions) : IRequestHandler<DeleteTicketCommand, Result>
    {
        public async Task<Result> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
        {
            return await actions.DeleteById<Ticket>(request.Id, cancellationToken);
        }
    }
}
