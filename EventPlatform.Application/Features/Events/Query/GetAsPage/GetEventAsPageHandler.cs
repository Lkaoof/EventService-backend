using AutoMapper;
using EventPlatform.Application.Extentions;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Application.Models.Domain.Events;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Events.Query.GetAsPage
{
    public class GetEventAsPageHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetEventAsPageQuery, Page<EventDto>>
    {
        public async Task<Page<EventDto>> Handle(GetEventAsPageQuery request, CancellationToken cancellationToken)
        {
            return await context.Events.AsQueryable().PaginateAsync<Event, EventDto>(request.Page, mapper, cancellationToken);
        }
    }
}
