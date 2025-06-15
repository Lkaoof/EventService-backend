using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Users;
using MediatR;

namespace EventPlatform.Application.Features.Users.Query.GetUserById
{
    public class GetUserByIdQuery : IRequest<Result<UserDetailDto>>, ICacheable
    {
        public Guid Id { get; set; }

        public string CacheKey => $"users:{Id}";
    }
}
