using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.Mapping;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Features.Tickets.Command.Create;
using EventPlatform.Application.Models.Domain.Events;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Events.Command.Create
{
    public class CreateEventCommand : IRequest<Result<EventDto>>, ICacheInvalidate, IMapWith<Event>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public uint TotalTickets { get; set; }
        public uint ReturnedTickets { get; set; }
        public DateTime EndAt { get; set; }
        public DateTime StartAt { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? ImageId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string AdditionalRequirements { get; set; } = string.Empty;
        public Guid CreatorId { get; set; }
        public Guid EventTypeId { get; set; }
        public Guid EventMoodId { get; set; }
        public ICollection<string> TagTitles { get; set; } = [];
        public ICollection<CreateTicketCommand> Tickets { get; set; } = [];

        public string[] CacheKeys => ["events*"];
    }
}
