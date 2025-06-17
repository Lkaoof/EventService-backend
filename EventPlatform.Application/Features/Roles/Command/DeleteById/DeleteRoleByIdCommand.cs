using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using MediatR;

namespace EventPlatform.Application.Features.Roles.Command.DeleteById
{
    public class DeleteRoleByIdCommand : IRequest<Result>, ICacheInvalidate
    {

        public Guid Id { get; set; }
        public string[] CacheKeys => [$"event:{Id}", "events*"];
    }
}
