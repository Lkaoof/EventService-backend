﻿using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.Users;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Users.Query.GetById
{
    public class GetUserByIdHandler(IActions actions) : IRequestHandler<GetUserByIdQuery, Result<UserDetailDto>>
    {
        public async Task<Result<UserDetailDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetById<User, UserDetailDto>(request.Id, cancellationToken);
        }
    }
}
