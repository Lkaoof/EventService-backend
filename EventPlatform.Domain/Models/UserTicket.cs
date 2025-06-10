namespace EventPlatform.Domain.Models
{
    public class UserTicket
    {
        public Guid Id { get; set; }

        public UserTicketStatus TicketStatus { get; set; }

        public decimal Price { get; set; }

        public Guid TicketId { get; set; }

        public Ticket Ticket { get; set; } = null!;

        public Guid UserId { get; set; }

        public User User { get; set; } = null!;
    }
}
