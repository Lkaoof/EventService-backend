using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.EventTypes;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.EventTypes.Command.Create
{
    public class CreateEventTypeHandler(IActions actions) : IRequestHandler<CreateEventTypeCommand, Result<EventTypeDto>>
    {
        public async Task<Result<EventTypeDto>> Handle(CreateEventTypeCommand request, CancellationToken cancellationToken)
        {
            return await actions.Create<EventType, EventTypeDto>(request.Entity, cancellationToken);
        }
    }
}
