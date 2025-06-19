using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.EventMoods;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.EventMoods.Query.GetById
{
    public class GetEventMoodByIdHandler(IActions actions) : IRequestHandler<GetEventMoodByIdQuery, Result<EventMoodDto>>
    {
        public async Task<Result<EventMoodDto>> Handle(GetEventMoodByIdQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetById<EventMood, EventMoodDto>(request.Id, cancellationToken);
        }
    }
}
