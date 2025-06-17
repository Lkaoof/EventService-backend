using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.Mapping;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Tickets;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Tickets.Command.Create
{
    public class CreateTicketCommand : IRequest<Result<TicketDto>>, ICacheInvalidate, IMapWith<Ticket>
    {
        public string Title { get; set; } = string.Empty;

        public decimal Price { get; set; }

        //public Guid EventId { get; set; }

        public string[] CacheKeys => ["tickets*"];
    }
}
