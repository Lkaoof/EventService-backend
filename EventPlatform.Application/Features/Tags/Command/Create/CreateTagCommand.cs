using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.Mapping;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Tags;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Tags.Command.Create
{
    public class CreateTagCommand : IRequest<Result<TagDto>>, ICacheInvalidate, IMapWith<Tag>

    {
        public string[] CacheKeys => ["tags*"];
    }
}
