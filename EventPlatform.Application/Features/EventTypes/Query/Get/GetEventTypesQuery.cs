using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Models.Domain.EventTypes;
using MediatR;

namespace EventPlatform.Application.Features.EventTypes.Query.Get
{
    public class GetEventTypesQuery : IRequest<ICollection<EventTypeDto>>, ICacheable
    {
        public string CacheKey => $"eventTypes";
    }
}
