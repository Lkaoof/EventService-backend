using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Events;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Events.Query.GetEventById
{
    public class GetEventByIdQuery : IRequest<Result<EventDto>>, ICacheable
    {
        public Guid Id { get; set; }

        public string CacheKey => $"events:{Id}";
    }
}
