using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.Roles
{
    public class RoleUpdateDto : IMapWith<Role>
    {
        public string? Name { get; set; }
        public bool? isPublic { get; set; }
    }
}
