using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.EventMoods
{
    public class EventMoodUpdateDto : IMapWith<EventMood>
    {
        public string? Title { get; set; }
    }
}
