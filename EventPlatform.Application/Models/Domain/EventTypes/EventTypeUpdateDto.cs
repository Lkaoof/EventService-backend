using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.EventTypes
{
    public class EventTypeUpdateDto : IMapWith<EventType>
    {
        public string? Title { get; set; }
        public bool? IsAvailable { get; set; }
    }
}
