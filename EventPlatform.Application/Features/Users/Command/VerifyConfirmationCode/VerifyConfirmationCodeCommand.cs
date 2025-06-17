using EventPlatform.Application.Common.ResultWrapper;
using MediatR;

namespace EventPlatform.Application.Features.Users.Command.VerifyConfirmationCode
{
    public class VerifyConfirmationCodeCommand : IRequest<Result>
    {
        public string Code { get; set; }
        public Guid UserId { get; set; }
    }
}
