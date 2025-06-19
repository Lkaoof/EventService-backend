using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
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
                (event_) =>
                {
                    if (event_.StartAt - DateTime.UtcNow <= TimeSpan.FromDays(1))
                    {
                        throw new InvalidOperationException("Cant edit event starting in less then 24 hours");
                    }
                    event_.Status = EventStatus.UnderModeration;
                });
        }
    }
}
