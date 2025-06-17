using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Features.Common;
using EventPlatform.Application.Models.Domain.EventMoods;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.EventMoods.Command.UpdateById
{
    public class UpdateEventMoodByIdHandler(IActions actions) : IRequestHandler<UpdateEventMoodByIdCommand, Result<EventMoodDto>>
    {
        public async Task<Result<EventMoodDto>> Handle(UpdateEventMoodByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.Update<EventMood, EventMoodDto>(request.Id, request.Entity, cancellationToken);
        }
    }
}
