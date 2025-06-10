using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventPlatform.Application.Extentions;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Pagination;
using EventPlatform.Cache;
using EventPlatform.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlatform.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICache _cache;
        private static readonly TimeSpan _cacheExpiration = TimeSpan.FromSeconds(10);
        public UserService(IUserRepository userRepository, ICache cache)
        {
            _userRepository = userRepository;
            _cache = cache;
        }

        public async Task<EntityMetadata> GetUsersMetadata(CancellationToken ct = default)
        {
            var count = await _userRepository.GetUsersAsQueryable(ct).CountAsync(ct);
            return new EntityMetadata { TotalCount = count };
        }

        public async Task<User?> GetUserById(Guid id, CancellationToken ct = default)
        {
            var fetch = async () => await _userRepository.GetUserByIdAsync(id, ct);
            return await _cache.GetOrSetAsync($"user-{id}", fetch, _cacheExpiration, ct);
        }

        public async Task<Page<User>> GetUsersAsPage(Pageable page, CancellationToken ct = default)
        {
            return await _userRepository.GetUsersAsQueryable(ct).PaginateAsync(page);
        }

        public async Task<IEnumerable<User>> GetUsers(CancellationToken ct = default)
        {
            var fetch = () => _userRepository.GetUsersAsync(ct);
            return await _cache.GetOrSetAsync($"users", fetch);
        }

        public async Task DeleteUserById(Guid id, CancellationToken ct = default)
        {
            Invalidate($"user-{id}", ct);
            await _userRepository.DeleteUserByIdAsync(id, ct);
        }

        private async void Invalidate(string key, CancellationToken ct = default)
        {
            Console.WriteLine($"Invalidate:{key}");
            await _cache.RemoveAsync(key, ct);
        }
    }
}
