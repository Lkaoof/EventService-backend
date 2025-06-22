using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.EventMoods
{
    public class EventMoodCreateDto : IMapWith<EventMood>
    {
        public string Title { get; set; } = string.Empty;
    }
}
