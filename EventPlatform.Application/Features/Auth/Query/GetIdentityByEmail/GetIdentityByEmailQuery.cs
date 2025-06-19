using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Users;
using MediatR;

namespace EventPlatform.Application.Features.Auth.Query.GetIdentityByEmail
{
    public class GetIdentityByEmailQuery : IRequest<Result<UserIdentity>>
    {
        public string Email { get; set; }
    }
}
