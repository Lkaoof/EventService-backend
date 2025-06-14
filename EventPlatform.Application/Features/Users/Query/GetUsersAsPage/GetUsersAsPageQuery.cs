using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Users.Query.GetUsersAsPage
{
    public class GetUsersAsPageQuery : IRequest<Page<User>>, ICacheable
    {
        public Pageable Page { get; set; }

        public string CacheKey => $"users:page:{Page.Index},{Page.Size}";
    }
}
