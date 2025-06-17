using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Models.Domain.Tags;
using MediatR;

namespace EventPlatform.Application.Features.Tags.Query.Get
{
    public class GetTagsQuery : IRequest<ICollection<TagDto>>, ICacheable
    {
        public string CacheKey => $"events";
    }
}
