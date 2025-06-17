using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Features.UserTickets.Command.UpdateById
{
    public class UserTicketUpdateDto : IMapWith<UserTicket>
    {
        public UserTicketStatus? TicketStatus { get; set; }

        //public decimal? Price { get; set; }
    }
}
