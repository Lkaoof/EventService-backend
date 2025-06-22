using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Roles;
using MediatR;

namespace EventPlatform.Application.Features.Roles.Command.Create
{
    public class CreateRoleCommand : IRequest<Result<RoleDto>>, ICacheInvalidate
    {
        public RoleCreateDto Entity { get; set; }
        public string[] CacheKeys => ["roles*"];
    }
}
