using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventPlatform.Application.Extentions;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Cache;
using EventPlatform.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlatform.Application.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDatabaseContext _context;

        public UserRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync(CancellationToken ct = default)
        {
            return await _context.Users.ToListAsync(ct);
        }

        public IQueryable<User> GetUsersAsQueryable(CancellationToken ct = default)
        {
            return _context.Users.AsQueryable();
        }

        public async Task<User?> GetUserByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _context.Users.FindAsync(id, ct);
        }

        public async Task DeleteUserByIdAsync(Guid id, CancellationToken ct = default)
        {
            await _context.Users
                .Where(u => u.Id == id)
                .ExecuteDeleteAsync(ct);
        }


    }
}
