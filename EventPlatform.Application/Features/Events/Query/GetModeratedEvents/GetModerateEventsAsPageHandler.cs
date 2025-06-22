using AutoMapper;
using EventPlatform.Application.Extentions;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Application.Models.Domain.Events;
using EventPlatform.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventPlatform.Application.Features.Events.Query.GetModeratedEvents
{
    public class GetModerateEventsAsPageHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetModerateEventsAsPageQuery, Page<EventDto>>
    {
        public async Task<Page<EventDto>> Handle(GetModerateEventsAsPageQuery request, CancellationToken cancellationToken)
        {
            return await context.Events
                .AsQueryable()
                .AsNoTracking()
                .Where(e => e.Status == EventStatus.UnderModeration)
                .OrderBy(e => e.StartAt)
                .PaginateAsync<Event, EventDto>
                (request.Page, mapper, cancellationToken);
        }
    }
}
