using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Models.Domain.Users;
using MediatR;

namespace EventPlatform.Application.Features.Users.Query.Get
{
    public class GetUsersQuery : IRequest<ICollection<UserDto>>, ICacheable
    {
        public string CacheKey => $"users";
    }
}