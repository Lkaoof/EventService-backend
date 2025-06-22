using EventPlatform.Domain.Commnon;

namespace EventPlatform.Domain.Models
{
    public class Ticket : BaseEntity
    {
        //public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public uint AvailableCount { get; set; }

        // Relations
        public Guid EventId { get; set; }

        public Event Event { get; set; } = null!;

        public ICollection<UserTicket> UserTickets { get; set; } = [];
    }
}
