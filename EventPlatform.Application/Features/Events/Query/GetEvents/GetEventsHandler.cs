using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventPlatform.Application.Features.Events.Query.GetEvents
{
    public class GetEventsHandler(IDatabaseContext context) : IRequestHandler<GetEventsQuery, ICollection<Event>>
    {
        public async Task<ICollection<Event>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            return await context.Events.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
