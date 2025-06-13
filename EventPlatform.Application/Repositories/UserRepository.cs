using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlatform.Application.Repositories
{
    public class UserRepository 
    {
        private readonly IDatabaseContext _context;

        public UserRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAsync(CancellationToken ct = default)
        {
            return await _context.Users.ToListAsync(ct);
        }

        public IQueryable<User> GetAsQueryable(CancellationToken ct = default)
        {
            return _context.Users.AsQueryable();
        }

        public async Task<User?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _context.Users.FindAsync(id, ct);
        }

        public void Create(User user)
        {

        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public async Task DeleterByIdAsync(Guid id, CancellationToken ct = default)
        {
            await _context.Users
                .Where(u => u.Id == id)
                .ExecuteDeleteAsync(ct);
        }


    }
}
