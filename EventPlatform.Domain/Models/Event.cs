using EventPlatform.Domain.Commnon;

namespace EventPlatform.Domain.Models
{
    public class Event : BaseEntity
    {
        //public Guid Id { get; set; }


        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public uint TotalTickets { get; set; }

        public uint ReturnedTickets { get; set; }

        public DateTime EndAt { get; set; }

        public DateTime StartAt { get; set; }

        public string Title { get; set; } = string.Empty;

        //public string City { get; set; } = string.Empty;

        public string? ImageId { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string AdditionalRequirements { get; set; } = string.Empty;

        public EventStatus Status { get; set; } = EventStatus.UnderModeration;


        // Relations
        public Guid CreatorId { get; set; }

        public Guid EventTypeId { get; set; }

        public Guid EventMoodId { get; set; }

        public User Creator { get; set; } = null!;

        public EventType EventType { get; set; } = null!;

        public EventMood EventMood { get; set; } = null!;

        public ICollection<Tag> Tags { get; set; } = [];

        public ICollection<Ticket> Tickets { get; set; } = [];
    }
}
