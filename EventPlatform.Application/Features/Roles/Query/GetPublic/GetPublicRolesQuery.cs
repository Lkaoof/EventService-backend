using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Models.Domain.Roles;
using MediatR;

namespace EventPlatform.Application.Features.Roles.Query.GetPublic
{
    public class GetPublicRolesQuery : IRequest<ICollection<RoleDto>>, ICacheable
    {
        public string CacheKey => $"roles:public";
    }
}
