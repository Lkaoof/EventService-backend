using EventPlatform.Application.Common.Mapping;
using EventPlatform.Application.Models.Domain.EventMoods;
using EventPlatform.Application.Models.Domain.EventTypes;
using EventPlatform.Application.Models.Domain.Tags;
using EventPlatform.Application.Models.Domain.Tickets;
using EventPlatform.Application.Models.Domain.Users;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.Events
{
    public class EventDetailDto : IMapWith<Event>
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public uint TotalTickets { get; set; }
        public uint AvailableTickets { get; set; }
        public DateTime EndAt { get; set; }
        public DateTime StartAt { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? ImageId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string AdditionalRequirements { get; set; } = string.Empty;
        public string ModerationStatus { get; set; } = null!;

        public UserDto Creator { get; set; } = null!;
        public EventTypeDto EventType { get; set; } = null!;
        public EventMoodDto EventMood { get; set; } = null!;
        public IEnumerable<TagDto> Tags { get; set; } = [];
        public IEnumerable<TicketDto> Tickets { get; set; } = [];
    }
}
