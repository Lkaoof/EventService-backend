using EventPlatform.Application.Features.Common;
using EventPlatform.Application.Models.Domain.UserTickets;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.UserTickets.Query.Get
{
    public class GetUserTicketsHandler(IActions actions) : IRequestHandler<GetUserTicketsQuery, ICollection<UserTicketDto>>
    {
        public async Task<ICollection<UserTicketDto>> Handle(GetUserTicketsQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetAll<UserTicket, UserTicketDto>(cancellationToken);
        }
    }
}
