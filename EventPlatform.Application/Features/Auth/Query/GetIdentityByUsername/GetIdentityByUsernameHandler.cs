using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.Users;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Auth.Query.GetIdentityByUsername
{
    public class GetIdentityByUsernameHandler(IActions actions) : IRequestHandler<GetIdentityByUsernameQuery, Result<UserIdentity>>
    {
        public async Task<Result<UserIdentity>> Handle(GetIdentityByUsernameQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetBy<User, UserIdentity>(user => user.Name, request.Username, cancellationToken);
        }
    }
}
