using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Tags;
using MediatR;

namespace EventPlatform.Application.Features.Tags.Command.UdpateById
{
    public class UpdateTagByIdCommand : IRequest<Result<TagDto>>, ICacheInvalidate
    {
        public Guid Id { get; set; }
        public TagUpdateDto Entity { get; set; }
        public string[] CacheKeys => [$"tag:{Id}", "tags*"];
    }
}
