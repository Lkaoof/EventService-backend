using EventPlatform.Application.Common.Mapping;
using EventPlatform.Application.Models.Domain.Roles;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.Users
{
    public class UserDetailDto : IMapWith<User>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<RoleDto> Roles { get; set; } = [];

    }
}
