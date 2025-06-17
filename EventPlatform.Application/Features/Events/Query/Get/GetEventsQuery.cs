using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Models.Domain.Events;
using MediatR;

namespace EventPlatform.Application.Features.Events.Query.Get
{
    public class GetEventsQuery : IRequest<ICollection<EventDto>>, ICacheable
    {
        public string CacheKey => $"events";
    }
}
