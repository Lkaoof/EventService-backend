using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Infrastructure;
using MediatR;

namespace EventPlatform.Application.Features.Users.Command.SendConfirmationCode
{
    public class SendConfirmationCodeHandler(IRandomCodeGeneration randomCode, IEmailSender emailSender, ICache cache) : IRequestHandler<SendConfirmationCodeCommand, Result>
    {
        public async Task<Result> Handle(SendConfirmationCodeCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Email))
                return Result.Failure("Email is required");

            string code = randomCode.GenerateRandomCode(6, true, true);

            await cache.StringSetAsync($"user_code:{request.UserId}", code, cancellationToken, TimeSpan.FromMinutes(1));

            string subject = "Код подтверждения";
            string content = $"{code}";

            await emailSender.SendAsync(request.Email, subject, content, cancellationToken);

            return Result.Success();
        }
    }
}
