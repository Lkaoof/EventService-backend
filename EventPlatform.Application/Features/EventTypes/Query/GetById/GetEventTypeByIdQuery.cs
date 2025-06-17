using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.EventTypes;
using MediatR;

namespace EventPlatform.Application.Features.EventTypes.Query.GetById
{
    public class GetEventTypeByIdQuery : IRequest<Result<EventTypeDto>>, ICacheable
    {
        public Guid Id { get; set; }

        public string CacheKey => $"events:{Id}";
    }
}
