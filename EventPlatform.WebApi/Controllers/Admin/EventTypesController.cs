using EventPlatform.Application.Features.EventTypes.Command.Create;
using EventPlatform.Application.Features.EventTypes.Command.DeleteById;
using EventPlatform.Application.Features.EventTypes.Command.UpdateById;
using EventPlatform.Application.Features.EventTypes.Query.Get;
using EventPlatform.Application.Features.EventTypes.Query.GetAsPage;
using EventPlatform.Application.Features.EventTypes.Query.GetById;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.WebApi.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPlatform.WebApi.Controllers.Basic
{
    [Tags("Admin")]
    [Authorize]
    [ApiController]
    [Route("/api/events/types")]
    public class EventTypesController(IMediator mediator) : ControllerApiBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetEventTypesQuery(), ct));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new GetEventTypeByIdQuery() { Id = id }, ct));
        }

        [HttpGet("page")]
        public async Task<IActionResult> GetAsPage([FromQuery] Pageable page, CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetEventTypeAsPageQuery() { Page = page }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEventTypeCommand request, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(request, ct));
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
