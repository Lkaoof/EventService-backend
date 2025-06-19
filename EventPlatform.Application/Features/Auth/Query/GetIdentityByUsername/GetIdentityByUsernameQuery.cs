using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Users;
using MediatR;

namespace EventPlatform.Application.Features.Auth.Query.GetIdentityByUsername
{
    public class GetIdentityByUsernameQuery : IRequest<Result<UserIdentity>>
    {
        public string Username { get; set; }
    }
}
