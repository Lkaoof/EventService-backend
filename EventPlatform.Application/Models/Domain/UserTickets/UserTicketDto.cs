namespace EventPlatform.Application.Models.Domain.UserTickets
{
    public class UserTicketDto
    {
        public Guid Id { get; set; }
        public string TicketTitle { get; set; } = null!;
        public string Status { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
