﻿using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Domain.Users;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Users.Command.Create
{
    public class CreateUserHandler(IPasswordHasher passwordHasher, IActions actions)
        : IRequestHandler<CreateUserCommand, Result<UserDto>>
    {
        public async Task<Result<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await actions.Create<User, UserDto>(request.Entity, cancellationToken,
                async (user, context) =>
                {
                    user.PasswordHash = passwordHasher.Hash(request.Entity.Password);

                    var roles = request.Entity.RoleIds
                        .Select(id => new Role() { Id = id })
                        .ToList();
                    context.Roles.AttachRange(roles);
                    user.Roles = roles;
                });
        }
    }
}
