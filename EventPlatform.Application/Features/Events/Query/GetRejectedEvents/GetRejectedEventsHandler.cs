using AutoMapper;
using EventPlatform.Application.Extentions;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Application.Models.Domain.Events;
using EventPlatform.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventPlatform.Application.Features.Events.Query.GetRejectedEvents
{
    public class GetRejectedEventsHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetRejectedEventsQuery, Page<EventDto>>
    {
        public async Task<Page<EventDto>> Handle(GetRejectedEventsQuery request, CancellationToken cancellationToken)
        {
            return await context.Events
                .AsQueryable()
                .AsNoTracking()
                .Where(e => e.Status == EventStatus.Rejected)
                .OrderBy(e => e.StartAt)
                .PaginateAsync<Event, EventDto>(request.Page, mapper, cancellationToken);
        }
    }
}
