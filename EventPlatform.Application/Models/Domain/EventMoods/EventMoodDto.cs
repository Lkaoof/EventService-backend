using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.EventMoods
{
    public class EventMoodDto : IMapWith<EventMood>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
