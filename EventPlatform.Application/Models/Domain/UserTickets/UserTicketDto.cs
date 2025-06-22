using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.UserTickets
{
    public class UserTicketDto : IMapWith<UserTicket>
    {
        public Guid Id { get; set; }
        public string TicketTitle { get; set; } = null!;
        public string TicketStatus { get; set; } = null!;
    }
}
