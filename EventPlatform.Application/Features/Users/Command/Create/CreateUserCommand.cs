using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Users;
using MediatR;

namespace EventPlatform.Application.Features.Users.Command.Create
{
    public class CreateUserCommand : IRequest<Result<UserDto>>, ICacheInvalidate
    {
        public UserCreateDto Entity { get; set; }

        public string[] CacheKeys => ["users*"];
    }
}
