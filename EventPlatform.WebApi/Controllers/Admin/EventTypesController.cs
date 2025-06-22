using EventPlatform.Application.Features.EventTypes.Command.Create;
using EventPlatform.Application.Features.EventTypes.Command.DeleteById;
using EventPlatform.Application.Features.EventTypes.Command.UpdateById;
using EventPlatform.Application.Features.EventTypes.Query.Get;
using EventPlatform.Application.Models.Domain.EventTypes;
using EventPlatform.WebApi.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPlatform.WebApi.Controllers.Basic
{
    [Tags("Admin")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("/api/events/types")]
    public class EventTypesController(IMediator mediator) : ControllerApiBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetEventTypesQuery(), ct));
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventTypeCreateDto enity, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new CreateEventTypeCommand() { Entity = enity }, ct));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, EventTypeUpdateDto dto, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new UpdateEventTypeByIdCommand() { Id = id, Entity = dto }, ct));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new DeleteEventTypeByIdCommand() { Id = id }, ct));
        }

    }
}
