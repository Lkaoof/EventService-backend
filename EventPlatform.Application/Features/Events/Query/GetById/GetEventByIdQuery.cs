using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Events;
using MediatR;

namespace EventPlatform.Application.Features.Events.Query.GetById
{
    public class GetEventByIdQuery : IRequest<Result<EventDetailDto>>, ICacheable
    {
        public Guid Id { get; set; }

        public string CacheKey => $"event:{Id}";
    }
}
