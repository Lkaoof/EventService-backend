using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Features.Common;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Domain.Events;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Events.Query.GetEventById
{
    public class GetEventByIdHandler(IDatabaseContext context, IActions actions) : IRequestHandler<GetEventByIdQuery, Result<EventDto>>
    {
        public async Task<Result<EventDto>> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetById<Event, EventDto>(request.Id, cancellationToken);
        }
    }
}
