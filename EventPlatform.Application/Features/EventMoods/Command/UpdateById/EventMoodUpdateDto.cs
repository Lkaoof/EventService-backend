using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Features.EventMoods.Command.UpdateById
{
    public class EventMoodUpdateDto : IMapWith<EventMood>
    {
        public string? Title { get; set; }
    }
}
