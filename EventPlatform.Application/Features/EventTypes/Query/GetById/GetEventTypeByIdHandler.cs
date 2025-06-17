using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Features.Common;
using EventPlatform.Application.Models.Domain.EventTypes;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.EventTypes.Query.GetById
{
    public class GetEventTypeByIdHandler(IActions actions) : IRequestHandler<GetEventTypeByIdQuery, Result<EventTypeDto>>
    {
        public async Task<Result<EventTypeDto>> Handle(GetEventTypeByIdQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetById<EventType, EventTypeDto>(request.Id, cancellationToken);
        }
    }
}
