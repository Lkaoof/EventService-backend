using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.Mapping;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Events;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Events.Command.CreateEvent
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

        public string[] CacheKeys => ["events*"];
    }
}
