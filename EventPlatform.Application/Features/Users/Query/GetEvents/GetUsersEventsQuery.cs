using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Models.Domain.Users;
using MediatR;

namespace EventPlatform.Application.Features.Users.Query.GetEvents
{
    public class GetUsersEventsQuery : IRequest<ICollection<UserEventDto>>, ICacheable
    {
        public Guid UserId { get; set; }
        public string CacheKey => $"user:{UserId}:events";
    }
}
