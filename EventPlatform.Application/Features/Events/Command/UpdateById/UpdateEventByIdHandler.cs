using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Features.Common;
using EventPlatform.Application.Models.Domain.Events;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Events.Command.UpdateById
{
    public class UpdateEventByIdHandler(IActions actions) : IRequestHandler<UpdateEventByIdCommand, Result<EventDto>>
    {
        public async Task<Result<EventDto>> Handle(UpdateEventByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.Update<Event, EventDto>(request.Id, request.Event, cancellationToken,
                (event_) => { event_.ModerationStatus = EventModerationStatus.UnderModeration; });
        }
    }
}
