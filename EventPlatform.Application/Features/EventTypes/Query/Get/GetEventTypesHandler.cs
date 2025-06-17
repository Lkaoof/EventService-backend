using EventPlatform.Application.Features.Common;
using EventPlatform.Application.Models.Domain.EventTypes;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.EventTypes.Query.Get
{
    public class GetEventTypesHandler(IActions actions) : IRequestHandler<GetEventTypesQuery, ICollection<EventTypeDto>>
    {
        public async Task<ICollection<EventTypeDto>> Handle(GetEventTypesQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetAll<EventType, EventTypeDto>(cancellationToken);
        }
    }
}
