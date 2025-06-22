using EventPlatform.Application.Features.Events.Command.Create;
using EventPlatform.Application.Features.Events.Command.DeleteById;
using EventPlatform.Application.Features.Events.Command.UpdateById;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Domain.Events;
using EventPlatform.Domain.Models;
using EventPlatform.WebApi.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPlatform.WebApi.Controllers.Customer
{
    [Tags("Events")]
    [Authorize(Roles = "Organizer, Admin")]
    [ApiController]
    [Route("/api/events")]
    public class EventsWriteController(IMediator mediator) : ControllerApiBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(EventCreateDto enity, IJobScheduler jobs, CancellationToken ct)
        {
            var create = await mediator.Send(new CreateEventCommand() { Entity = enity }, ct);
            if (create.IsFailure) return ToActionResult(create);
            var event_ = create.Value!;

            await jobs.ScheduleChangeEventStatus(event_.StartAt, EventStatus.Finished, event_.Id, ct);

            return ToActionResult(create);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, EventUpdateDto dto, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new UpdateEventByIdCommand() { Id = id, Event = dto }, ct));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new DeleteEventByIdCommand() { Id = id }, ct));
        }
    }
}
