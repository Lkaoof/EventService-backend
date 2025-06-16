using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
