using EventPlatform.Application.Features.Common;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Domain.Events;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Events.Query.GetEvents
{
    public class GetEventsHandler(IDatabaseContext context, IActions actions) : IRequestHandler<GetEventsQuery, ICollection<EventDto>>
    {
        public async Task<ICollection<EventDto>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetAll<Event, EventDto>(cancellationToken);
        }
    }
}
