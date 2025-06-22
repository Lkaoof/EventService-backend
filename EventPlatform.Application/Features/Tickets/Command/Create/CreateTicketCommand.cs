using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Tickets;
using MediatR;

namespace EventPlatform.Application.Features.Tickets.Command.Create
{
    public class CreateTicketCommand : IRequest<Result<TicketDto>>, ICacheInvalidate
    {
        public Guid EventId { get; set; }

        public TicketCreateDto Entity { get; set; }
        public string[] CacheKeys => ["tickets*", $"event:{EventId}"];
    }
}
