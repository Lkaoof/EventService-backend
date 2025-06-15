using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Features.Users.Command.UpdateUserById
{
    public class UserUpdateDto : IMapWith<User>
    {
        public string? Email { get; set; }

        public string? Name { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Password { get; set; }

        public DateTime? Birthdate { get; set; }
    }
}
