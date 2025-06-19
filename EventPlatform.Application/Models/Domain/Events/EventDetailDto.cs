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
        public string Title { get; set; }
        public string? ImageId { get; set; }
        public string Description { get; set; }
        public string AdditionalRequirements { get; set; }
        public string Status { get; set; } = null!;

        public UserDto Creator { get; set; } = null!;
        public EventTypeDto EventType { get; set; } = null!;
        public EventMoodDto EventMood { get; set; } = null!;
        public ICollection<TagDto> Tags { get; set; } = [];
        public ICollection<TicketDto> Tickets { get; set; } = [];

    }
}
