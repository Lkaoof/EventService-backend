using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Features.Common;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Domain.Users;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Users.Query.GetUserById
{
    public class GetUserByIdHandler(IDatabaseContext context, IActions actions) : IRequestHandler<GetUserByIdQuery, Result<UserDetailDto>>
    {
        public async Task<Result<UserDetailDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetById<User, UserDetailDto>(request.Id, cancellationToken);
        }
    }
}
