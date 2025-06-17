using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Tickets;
using MediatR;

namespace EventPlatform.Application.Features.Tickets.Command.UpdateById
{
    public class UpdateTicketCommand : IRequest<Result<TicketDto>>, ICacheInvalidate
    {
        public Guid Id { get; set; }
        public TicketUpdateDto Entity { get; set; }
        public string[] CacheKeys => [$"ticket:{Id}", "tickets*"];
    }
}
