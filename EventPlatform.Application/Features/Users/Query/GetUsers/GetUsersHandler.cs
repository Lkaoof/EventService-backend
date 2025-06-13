using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventPlatform.Application.Features.Users.Query.GetUsers
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, List<User>>
    {
        private readonly IDatabaseContext _context;

        public GetUsersHandler(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
