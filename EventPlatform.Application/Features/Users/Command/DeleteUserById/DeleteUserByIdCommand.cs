using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventPlatform.Application.Common.CacheBehavior;
using MediatR;

namespace EventPlatform.Application.Features.Users.Command.DeleteUserById
{
    public class DeleteUserByIdCommand : IRequest, ICacheInvalidate
    {
        public Guid Id { get; set; }

        public string[] CacheKeys => ["users"];
    }
}
