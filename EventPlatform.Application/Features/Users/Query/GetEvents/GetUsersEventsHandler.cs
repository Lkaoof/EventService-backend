using AutoMapper;
using AutoMapper.QueryableExtensions;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Domain.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventPlatform.Application.Features.Users.Query.GetEvents
{
    public class GetUsersEventsHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetUsersEventsQuery, ICollection<UserEventDto>>
    {
        public async Task<ICollection<UserEventDto>> Handle(GetUsersEventsQuery request, CancellationToken cancellationToken)
        {
            return await context.Events
                .AsNoTracking()
                .Where(e => e.CreatorId == request.UserId)
                .ProjectTo<UserEventDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
