using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Features.EventTypes.Command.UpdateById
{
    public class EventTypeUpdateDto : IMapWith<EventType>
    {
        public string? Title { get; set; }
        public bool? IsAvailable { get; set; }
    }
}
