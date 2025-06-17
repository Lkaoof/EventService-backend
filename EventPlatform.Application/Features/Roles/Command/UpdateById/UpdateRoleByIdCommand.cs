using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Roles;
using MediatR;

namespace EventPlatform.Application.Features.Roles.Command.UpdateById
{
    public class UpdateRoleByIdCommand : IRequest<Result<RoleDto>>, ICacheInvalidate

    {
        public Guid Id { get; set; }

        public RoleUpdateDto Entity { get; set; }

        public string[] CacheKeys => [$"role:{Id}", "roles*"];
    }
}
