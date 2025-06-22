using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.EventTypes
{
    public class EventTypeCreateDto : IMapWith<EventType>
    {
        public string Title { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true;
    }
}
