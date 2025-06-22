using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Tags;
using MediatR;

namespace EventPlatform.Application.Features.Tags.Command.Create
{
    public class CreateTagCommand : IRequest<Result<TagDto>>, ICacheInvalidate
    {
        public TagCreateDto Entity { get; set; }
        public string[] CacheKeys => ["tags*"];
    }
}
