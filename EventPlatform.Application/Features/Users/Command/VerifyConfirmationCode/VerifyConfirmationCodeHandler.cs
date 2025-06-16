using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Features.Users.Command.SendConfirmationCode;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.RandomCodeGeneration;
using MediatR;

namespace EventPlatform.Application.Features.Users.Command.VerifyConfirmationCode
{
    public class VerifyConfirmationCodeHandler(ICache cache) : IRequestHandler<VerifyConfirmationCodeCommand, Result>
    {
        public async Task<Result> Handle(VerifyConfirmationCodeCommand request, CancellationToken cancellationToken)
        {
            var storedCode = await cache.StringGetAsync($"user_code:{request.UserId}", cancellationToken);
            return storedCode == request.Code ? Result.Success() : Result.Failure(status: Status.NotFound);
        }
    }
}
