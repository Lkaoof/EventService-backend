using EventPlatform.Application.Features.Events.Query.GetById;
using EventPlatform.Application.Features.Tickets.Command.Create;
using EventPlatform.Application.Features.Tickets.Command.DeleteById;
using EventPlatform.Application.Features.Tickets.Command.UpdateById;
using EventPlatform.Application.Models.Domain.Tickets;
using EventPlatform.WebApi.Common;
using EventPlatform.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPlatform.WebApi.Controllers.Customer
{
    [Tags("Tickets")]
    [Authorize(Roles = "Organizer")]
    [ApiController]
    [Route("/api/tickets")]
    public class TicketsWriteController(IMediator mediator) : ControllerApiBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(Guid eventId, TicketCreateDto enity, CancellationToken ct)
        {
            var check = await CheckUserEvent(eventId, ct);
            if (check != null) return check;

            return ToActionResult(await mediator.Send(new CreateTicketCommand() { EventId = eventId, Entity = enity }, ct));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid ticketId, Guid eventId, TicketUpdateDto dto, CancellationToken ct)
        {
            var check = await CheckUserEvent(eventId, ct);
            if (check != null) return check;

            return ToActionResult(await mediator.Send(new UpdateTicketCommand() { Id = ticketId, Entity = dto }, ct));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid ticketId, Guid eventId, CancellationToken ct)
        {
            var check = await CheckUserEvent(eventId, ct);
            if (check != null) return check;

            return ToActionResult(await mediator.Send(new DeleteTicketCommand() { Id = ticketId }, ct));
        }

        private async Task<IActionResult> CheckUserEvent(Guid eventId, CancellationToken ct = default)
        {
            var event_ = await mediator.Send(new GetEventByIdQuery() { Id = eventId }, ct);
            if (event_.IsFailure) return ToActionResult(event_);
            if (event_.Value!.Creator.Id != User.Id()) return Forbid();
            return null;
        }
    }
}
