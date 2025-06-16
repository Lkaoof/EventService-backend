using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventPlatform.Application.Common.ResultWrapper;
using MediatR;

namespace EventPlatform.Application.Features.Users.Command.SendConfirmationCode
{
    public class SendConfirmationCodeCommand : IRequest<Result>
    {
        public string Email {  get; set; }

        public Guid UserId { get; set; }
    }
}
