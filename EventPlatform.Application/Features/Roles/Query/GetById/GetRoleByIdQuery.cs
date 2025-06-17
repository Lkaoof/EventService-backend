using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Roles;
using MediatR;

namespace EventPlatform.Application.Features.Roles.Query.GetById
{
    public class GetRoleByIdQuery : IRequest<Result<RoleDto>>, ICacheable
    {
        public Guid Id { get; set; }

        public string CacheKey => $"role:{Id}";
    }
}
