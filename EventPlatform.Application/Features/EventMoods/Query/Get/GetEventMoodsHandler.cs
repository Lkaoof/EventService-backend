using EventPlatform.Application.Features.Common;
using EventPlatform.Application.Models.Domain.EventMoods;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.EventMoods.Query.Get
{
    public class GetEventMoodsHandler(IActions actions) : IRequestHandler<GetEventMoodsQuery, ICollection<EventMoodDto>>
    {
        public async Task<ICollection<EventMoodDto>> Handle(GetEventMoodsQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetAll<EventMood, EventMoodDto>(cancellationToken);
        }
    }
}
