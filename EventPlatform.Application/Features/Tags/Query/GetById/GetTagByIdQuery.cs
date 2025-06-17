using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Tags;
using MediatR;

namespace EventPlatform.Application.Features.Tags.Query.GetById
{
    public class GetTagByIdQuery : IRequest<Result<TagDto>>, ICacheable
    {
        public Guid Id { get; set; }
        public string CacheKey => $"tag:{Id}";
    }
}
