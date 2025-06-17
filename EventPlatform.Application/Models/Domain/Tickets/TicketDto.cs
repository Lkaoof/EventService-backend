using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.Tickets
{
    public class TicketDto : IMapWith<Ticket>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public Guid EventId { get; set; }
    }
}
