using AutoMapper;
using EventPlatform.Application.Extentions;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Application.Models.Domain.EventTypes;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.EventTypes.Query.GetAsPage
{
    public class GetEventTypeAsPageHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetEventTypeAsPageQuery, Page<EventTypeDto>>
    {
        public async Task<Page<EventTypeDto>> Handle(GetEventTypeAsPageQuery request, CancellationToken cancellationToken)
        {
            return await context.EventTypes.AsQueryable().PaginateAsync<EventType, EventTypeDto>(request.Page, mapper, cancellationToken);
        }
    }
}
