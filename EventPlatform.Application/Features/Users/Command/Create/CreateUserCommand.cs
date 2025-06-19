using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.Mapping;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Users;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Users.Command.Create
{
    public class CreateUserCommand : IRequest<Result<UserDto>>, ICacheInvalidate, IMapWith<User>
    {
        public string Email { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public DateTime Birthdate { get; set; }

        public string ConfirmationCode { get; set; } = string.Empty;

        public string[] CacheKeys => ["users*"];
    }
}
