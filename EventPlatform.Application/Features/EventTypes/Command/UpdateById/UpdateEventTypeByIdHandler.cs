using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.EventTypes;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.EventTypes.Command.UpdateById
{
    public class UpdateEventTypeByIdHandler(IActions actions) : IRequestHandler<UpdateEventTypeByIdCommand, Result<EventTypeDto>>
    {
        public async Task<Result<EventTypeDto>> Handle(UpdateEventTypeByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.Update<EventType, EventTypeDto>(request.Id, request.Entity);
        }
    }
}
