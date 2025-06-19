using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Users;
using MediatR;

namespace EventPlatform.Application.Features.Auth.Query.GetIdentityById
{
    public class GetIdentityByIdQuery : IRequest<Result<UserIdentity>>, ICacheable
    {
        public Guid Id { get; set; }

        public string CacheKey => $"user:{Id}:identity";
    }
}
