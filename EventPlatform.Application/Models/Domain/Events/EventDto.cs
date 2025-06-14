using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.Events
{
    public class EventDto : IMapWith<Event>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime StartAt { get; set; }
        public string? ImageId { get; set; }
        public string EventType { get; set; } = null!;
        public string EventMood { get; set; } = null!;
        public string CreatorName { get; set; } = null!;
    }
}
