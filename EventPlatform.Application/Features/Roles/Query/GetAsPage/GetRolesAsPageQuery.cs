using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Application.Models.Domain.Roles;
using MediatR;

namespace EventPlatform.Application.Features.Roles.Query.GetAsPage
{
    public class GetRolesAsPageQuery : IRequest<Page<RoleDto>>, ICacheable
    {
        public Pageable Page { get; set; }
        public string CacheKey => $"roles:page:{Page.Index},{Page.Size}";
    }
}
