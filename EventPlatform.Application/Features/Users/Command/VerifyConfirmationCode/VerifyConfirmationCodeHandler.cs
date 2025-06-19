using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Infrastructure;
using MediatR;

namespace EventPlatform.Application.Features.Users.Command.VerifyConfirmationCode
{
    public class VerifyConfirmationCodeHandler(ICache cache) : IRequestHandler<VerifyConfirmationCodeCommand, Result>
    {
        public async Task<Result> Handle(VerifyConfirmationCodeCommand request, CancellationToken cancellationToken)
        {
            var storedCode = await cache.StringGetAsync($"user_code:{request.Email}", cancellationToken);
            return storedCode == request.Code ? Result.Success() : Result.Failure("Code not found",Status.NotFound);
        }
    }
}
