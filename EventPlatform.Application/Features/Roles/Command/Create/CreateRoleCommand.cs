using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.Mapping;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Roles;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Roles.Command.Create
{
    public class CreateRoleCommand : IRequest<Result<RoleDto>>, ICacheInvalidate, IMapWith<Role>
    {
        public string Name { get; set; } = string.Empty;
        public string[] CacheKeys => ["roles*"];
    }
}
