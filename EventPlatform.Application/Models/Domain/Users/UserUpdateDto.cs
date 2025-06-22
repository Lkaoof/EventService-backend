using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.Users
{
    public class UserUpdateDto : IMapWith<User>
    {
        public string? Name { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime? Birthdate { get; set; }
    }
}
