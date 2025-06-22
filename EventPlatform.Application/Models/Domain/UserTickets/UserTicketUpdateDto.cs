using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.UserTickets
{
    public class UserTicketUpdateDto : IMapWith<UserTicket>
    {
        public UserTicketStatus? TicketStatus { get; set; }

        //public decimal? Price { get; set; }
    }
}
