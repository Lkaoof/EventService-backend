using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.EventMoods;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.EventMoods.Command.Create
{
    public class CreateEventMoodHandler(IActions actions) : IRequestHandler<CreateEventMoodCommand, Result<EventMoodDto>>
    {
        public async Task<Result<EventMoodDto>> Handle(CreateEventMoodCommand request, CancellationToken cancellationToken)
        {
            return await actions.Create<EventMood, EventMoodDto>(request.Entity, cancellationToken);
        }
    }
}
