using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.Mapping;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.EventMoods;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.EventMoods.Command.Create
{
    public class CreateEventMoodCommand : IRequest<Result<EventMoodDto>>, ICacheInvalidate, IMapWith<EventMood>
    {
        public string Title { get; set; } = string.Empty;
        public string[] CacheKeys => ["event_moods*"];
    }
}
