using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.Users;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Auth.Query.GetIdentityByEmail
{
    public class GetIdentityByEmailHandler(IActions actions) : IRequestHandler<GetIdentityByEmailQuery, Result<UserIdentity>>
    {
        public async Task<Result<UserIdentity>> Handle(GetIdentityByEmailQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetBy<User, UserIdentity>(user => user.Email, request.Email, cancellationToken);
        }
    }
}
