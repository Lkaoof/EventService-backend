using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using MediatR;

namespace EventPlatform.Application.Features.Users.Command.DeleteById
{
    public class DeleteUserByIdCommand : IRequest<Result>, ICacheInvalidate
    {
        public Guid Id { get; set; }

        public string[] CacheKeys => ["users*"];
    }
}
