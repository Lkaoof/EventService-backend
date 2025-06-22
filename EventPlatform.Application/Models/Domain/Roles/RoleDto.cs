using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.Roles
{
    public class RoleDto : IMapWith<Role>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool isPublic { get; set; }
    }
}
