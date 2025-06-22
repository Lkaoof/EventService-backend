using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.Users
{
    public class UserCreateDto : IMapWith<User>
    {
        public string Email { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public DateTime Birthdate { get; set; }

        public string ConfirmationCode { get; set; } = string.Empty;

        public ICollection<Guid> RoleIds { get; set; } = [];

    }
}
