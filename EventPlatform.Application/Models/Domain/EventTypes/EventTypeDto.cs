using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.EventTypes
{
    public class EventTypeDto : IMapWith<EventType>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true;
    }
}
