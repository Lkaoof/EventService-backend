using AutoMapper;
using EventPlatform.Application.Extentions;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Application.Models.Domain.Events;
using EventPlatform.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventPlatform.Application.Features.Events.Query.GetApprovedEvents
{
    public class GetApprovedEventsHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetApprovedEventsQuery, Page<EventDto>>
    {
        public async Task<Page<EventDto>> Handle(GetApprovedEventsQuery request, CancellationToken cancellationToken)
        {
            return await context.Events
                .AsQueryable()
                .AsNoTracking()
                .Where(e => e.Status == EventStatus.Approved)
                .OrderBy(e => e.StartAt)
                .PaginateAsync<Event, EventDto>
                (request.Page, mapper, cancellationToken);
        }
    }
}
