using EventPlatform.Application.Common.Mapping;
using EventPlatform.Application.Models.Domain.EventMoods;
using EventPlatform.Application.Models.Domain.EventTypes;
using EventPlatform.Application.Models.Domain.Users;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.Events
{
    public class EventDto : IMapWith<Event>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime StartAt { get; set; }
        public string? ImageId { get; set; }
        public EventTypeDto EventType { get; set; } = null!;
        public EventMoodDto EventMood { get; set; } = null!;
        public UserDto Creator { get; set; } = null!;
    }
}
