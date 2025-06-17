using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Features.Common;
using EventPlatform.Application.Models.Domain.UserTickets;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.UserTickets.Command.Create
{
    public class CreateUserTicketHandler(IActions actions) : IRequestHandler<CreateUserTicketCommand, Result<UserTicketDto>>
    {
        public async Task<Result<UserTicketDto>> Handle(CreateUserTicketCommand request, CancellationToken cancellationToken)
        {
            return await actions.Create<UserTicket, UserTicketDto>(request, cancellationToken);
        }
    }
}
