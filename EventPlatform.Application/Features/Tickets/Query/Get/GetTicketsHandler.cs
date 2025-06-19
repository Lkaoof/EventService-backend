using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.Tickets;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Tickets.Query.Get
{
    public class GetTicketsHandler(IActions actions) : IRequestHandler<GetTicketsQuery, ICollection<TicketDto>>
    {
        public async Task<ICollection<TicketDto>> Handle(GetTicketsQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetAll<Ticket, TicketDto>(cancellationToken);
        }
    }
}
