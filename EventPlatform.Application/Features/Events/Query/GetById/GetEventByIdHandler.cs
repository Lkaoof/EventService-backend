using AutoMapper;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.Events;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Events.Query.GetById
{
    public class GetEventByIdHandler(IActions actions, IMapper mapper) : IRequestHandler<GetEventByIdQuery, Result<EventDetailDto>>
    {
        public async Task<Result<EventDetailDto>> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetById<Event, EventDetailDto>(request.Id, cancellationToken);
        }
    }
}
