using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Events.Query.GetEvents
{
    public class GetEventsQuery : IRequest<ICollection<Event>>, ICacheable
    {
        public string CacheKey => $"events";
    }
}
