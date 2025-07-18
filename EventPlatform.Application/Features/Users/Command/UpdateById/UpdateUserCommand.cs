﻿using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Users;
using MediatR;

namespace EventPlatform.Application.Features.Users.Command.UpdateById
{
    public class UpdateUserCommand : IRequest<Result<UserDto>>, ICacheInvalidate
    {
        public Guid Id { get; set; }

        public UserUpdateDto User { get; set; }

        public string[] CacheKeys => [$"user:{Id}", "users*"];
    }
}
