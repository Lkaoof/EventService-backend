using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Models.Domain.Roles;
using MediatR;

namespace EventPlatform.Application.Features.Roles.Query.Get
{
    public class GetRolesQuery : IRequest<ICollection<RoleDto>>, ICacheable
    {
        public string CacheKey => $"events";
    }
}
