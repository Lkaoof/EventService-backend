using EventPlatform.Domain.Commnon;

namespace EventPlatform.Domain.Models
{
    public class UserTicket : BaseEntity
    {
        //public Guid Id { get; set; }

        public UserTicketStatus TicketStatus { get; set; } = UserTicketStatus.Active;

        public Guid TicketId { get; set; }

        public Ticket Ticket { get; set; } = null!;

        public Guid UserId { get; set; }

        public User User { get; set; } = null!;
    }
}
