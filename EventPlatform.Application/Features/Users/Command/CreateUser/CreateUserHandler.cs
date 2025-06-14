using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Features.Common;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Domain.Users;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Users.Command.CreateUser
{
    public class CreateUserHandler(IDatabaseContext context, IPasswordHasher passwordHasher, IActions actions)
        : IRequestHandler<CreateUserCommand, Result<UserDto>>
    {
        public async Task<Result<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await actions.Create<User, UserDto, CreateUserCommand>(
                context.Users,
                request,
                cancellationToken,
                (user) => user.PasswordHash = passwordHasher.Hash(request.Password));
        }
    }
}
