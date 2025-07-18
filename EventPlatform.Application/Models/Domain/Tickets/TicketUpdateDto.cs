﻿using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.Tickets
{
    public class TicketUpdateDto : IMapWith<Ticket>
    {
        public string? Title { get; set; }
        public decimal? Price { get; set; }
    }
}
