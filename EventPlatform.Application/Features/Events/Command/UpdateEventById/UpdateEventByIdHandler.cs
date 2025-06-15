using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Features.Common;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Domain.Events;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Events.Command.UpdateEventById
{
    public class UpdateEventByIdHandler(IDatabaseContext context, IActions actions) : IRequestHandler<UpdateEventByIdCommand, Result<EventDto>>
    {
        public async Task<Result<EventDto>> Handle(UpdateEventByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.Update<Event, EventDto>(request.Id, request.Event, cancellationToken);
        }
    }
}
