using AutoMapper;
using AutoMapper.QueryableExtensions;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Domain.UserTickets;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventPlatform.Application.Features.Users.Query.GetTickets
{
    public class GetUsersTicketsHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetUsersTicketsQuery, ICollection<UserTicketDto>>
    {
        public async Task<ICollection<UserTicketDto>> Handle(GetUsersTicketsQuery request, CancellationToken cancellationToken)
        {
            return await context.UsersTickets
                .AsNoTracking()
                .Where(ut => ut.UserId == request.UserId)
                .ProjectTo<UserTicketDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
