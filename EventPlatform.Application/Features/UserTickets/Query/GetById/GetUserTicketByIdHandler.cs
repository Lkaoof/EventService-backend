using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.UserTickets;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.UserTickets.Query.GetById
{
    public class GetUserTicketByIdHandler(IActions actions) : IRequestHandler<GetUserTicketByIdQuery, Result<UserTicketDto>>
    {
        public async Task<Result<UserTicketDto>> Handle(GetUserTicketByIdQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetById<UserTicket, UserTicketDto>(request.Id, cancellationToken);
        }
    }
}
