using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.Users;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Auth.Query.GetIdentityById
{
    public class GetIdentityByIdHandler(IActions actions) : IRequestHandler<GetIdentityByIdQuery, Result<UserIdentity>>
    {
        public async Task<Result<UserIdentity>> Handle(GetIdentityByIdQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetById<User, UserIdentity>(request.Id, cancellationToken);
        }
    }
}
