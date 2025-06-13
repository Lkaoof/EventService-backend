using EventPlatform.Application.Extentions;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Pagination;
using EventPlatform.Application.Repositories;
using EventPlatform.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlatform.Application.Services
{
    public class UserService 
    {
        private readonly UserRepository _userRepository;
        private readonly ICache _cache;
        private static readonly TimeSpan _cacheExpiration = TimeSpan.FromSeconds(10);

        public UserService(UserRepository userRepository, ICache cache)
        {
            _userRepository = userRepository;
            _cache = cache;
        }

        public async Task<EntityMetadata> GetUsersMetadata(CancellationToken ct = default)
        {
            var count = await _userRepository.GetAsQueryable(ct).CountAsync(ct);
            return new EntityMetadata { TotalCount = count };
        }

        public async Task<User?> GetUserById(Guid id, CancellationToken ct = default)
        {
            var fetch = async () => await _userRepository.GetByIdAsync(id, ct);
            return await _cache.GetOrSetAsync($"user-{id}", fetch, _cacheExpiration, ct);
        }

        public async Task<Page<User>> GetUsersAsPage(Pageable page, CancellationToken ct = default)
        {
            return await _userRepository.GetAsQueryable(ct).PaginateAsync(page);
        }

        public async Task<IEnumerable<User>> GetUsers(CancellationToken ct = default)
        {
            var fetch = () => _userRepository.GetAsync(ct);
            return await _cache.GetOrSetAsync($"users", fetch);
        }

        public async Task DeleteUserById(Guid id, CancellationToken ct = default)
        {
            Invalidate($"user-{id}", ct);
            await _userRepository.DeleterByIdAsync(id, ct);
        }

        private async void Invalidate(string key, CancellationToken ct = default)
        {
            Console.WriteLine($"Invalidate:{key}");
            await _cache.RemoveAsync(key, ct);
        }
    }
}
