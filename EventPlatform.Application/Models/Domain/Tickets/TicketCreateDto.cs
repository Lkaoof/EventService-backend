using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.Tickets
{
    public class TicketCreateDto : IMapWith<Ticket>
    {
        public string Title { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public uint AvailableCount { get; set; }
    }
}
