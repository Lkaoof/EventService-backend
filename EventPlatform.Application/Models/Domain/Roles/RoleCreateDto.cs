using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.Roles
{
    public class RoleCreateDto : IMapWith<Role>
    {
        public string Name { get; set; } = string.Empty;

        public bool isPublic { get; set; }
    }
}
