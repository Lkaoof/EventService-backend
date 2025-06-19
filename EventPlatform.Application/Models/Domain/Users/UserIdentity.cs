using EventPlatform.Application.Common.Mapping;
using EventPlatform.Application.Models.Domain.Roles;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.Users
{
    public class UserIdentity : IMapWith<User>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public DateTime PasswordUpdatedAt { get; set; }
        public ICollection<RoleDto> Roles { get; set; } = [];
    }
}
