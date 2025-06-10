using EventPlatform.Application.Models.Pagination;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Interfaces.Application
{
    public interface IUserService
    {
        Task DeleteUserById(Guid id, CancellationToken ct = default);
        Task<Page<User>> GetUsersAsPage(Pageable page, CancellationToken ct = default);
        Task<User?> GetUserById(Guid id, CancellationToken ct = default);
        Task<IEnumerable<User>> GetUsers(CancellationToken ct = default);
        Task<EntityMetadata> GetUsersMetadata(CancellationToken ct = default);
    }
}