using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Features.Common;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Domain.Events;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Events.Command.CreateEvent
{
    public class CreateEventHandler(IDatabaseContext context, IActions actions) : IRequestHandler<CreateEventCommand, Result<EventDto>>
    {
        public async Task<Result<EventDto>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            return await actions.Create<Event, EventDto>(request, cancellationToken);
        }
    }
}
