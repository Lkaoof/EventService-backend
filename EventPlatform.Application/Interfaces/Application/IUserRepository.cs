using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Interfaces.Application
{
    public interface IUserRepository
    {
        Task DeleteUserByIdAsync(Guid id, CancellationToken ct = default);
        Task<User?> GetUserByIdAsync(Guid id, CancellationToken ct = default);
        IQueryable<User> GetUsersAsQueryable(CancellationToken ct = default);
        Task<IEnumerable<User>> GetUsersAsync(CancellationToken ct = default);
    }
}