using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Features.Roles.Command.UpdateById
{
    public class RoleUpdateDto : IMapWith<Role>
    {
        public string? Name { get; set; }
    }
}
