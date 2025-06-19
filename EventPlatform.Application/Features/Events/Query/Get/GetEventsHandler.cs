using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.Events;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Events.Query.Get
{
    public class GetEventsHandler(IActions actions) : IRequestHandler<GetEventsQuery, ICollection<EventDto>>
    {
        public async Task<ICollection<EventDto>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetAll<Event, EventDto>(cancellationToken);
        }
    }
}
