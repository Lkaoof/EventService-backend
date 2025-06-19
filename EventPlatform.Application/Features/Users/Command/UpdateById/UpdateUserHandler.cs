using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Domain.Users;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Users.Command.UpdateById
{
    public class UpdateUserHandler(IActions actions, IPasswordHasher hasher) : IRequestHandler<UpdateUserCommand, Result<UserDto>>
    {
        public async Task<Result<UserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await actions.Update<User, UserDto>(request.Id, request.User, cancellationToken, (user) =>
            {
                var now = DateTime.UtcNow;
                user.LastUpdatedAt = now;
                if (request.User.Password != null)
                {
                    user.PasswordHash = hasher.Hash(request.User.Password);
                    user.PasswordUpdatedAt = now;
                }
            });
        }
    }
}
