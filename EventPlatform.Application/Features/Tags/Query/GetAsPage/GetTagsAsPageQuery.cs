using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Application.Models.Domain.Tags;
using MediatR;

namespace EventPlatform.Application.Features.Tags.Query.GetAsPage
{
    public class GetTagsAsPageQuery : IRequest<Page<TagDto>>, ICacheable
    {
        public Pageable Page { get; set; }
        public string CacheKey => $"tags:page:{Page.Index},{Page.Size}";
    }
}
