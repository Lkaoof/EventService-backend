using EventPlatform.Application.Common.ResultWrapper;
using MediatR;

namespace EventPlatform.Application.Features.Auth.Command.ChangePassowrd
{
    public class ChangeUserPasswordCommand : IRequest<Result>
    {
        public Guid UserId { get; set; }

        public string Password { get; set; }

    }
}
