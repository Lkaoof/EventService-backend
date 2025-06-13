using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Users.Query.GetUsers
{
    public class GetUsersQuery : IRequest<List<User>>, ICacheable
    {
        public string CacheKey => $"users";
    }
}