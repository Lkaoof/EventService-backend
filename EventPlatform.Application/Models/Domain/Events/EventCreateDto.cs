﻿using EventPlatform.Application.Common.Mapping;
using EventPlatform.Application.Models.Domain.Tickets;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.Events
{
    public class EventCreateDto : IMapWith<Event>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
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
        public ICollection<TicketCreateDto> Tickets { get; set; } = [];
    }
}
