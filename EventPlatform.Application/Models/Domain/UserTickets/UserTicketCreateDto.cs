using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.UserTickets
{
    public class UserTicketCreateDto : IMapWith<UserTicket>
    {
        public Guid TicketId { get; set; }
        public Guid UserId { get; set; }
    }
}
