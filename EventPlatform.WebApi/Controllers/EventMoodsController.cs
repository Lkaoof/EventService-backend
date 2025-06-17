using EventPlatform.Application.Features.EventMoods.Command.Create;
using EventPlatform.Application.Features.EventMoods.Command.DeleteById;
using EventPlatform.Application.Features.EventMoods.Command.UpdateById;
using EventPlatform.Application.Features.EventMoods.Query.Get;
using EventPlatform.Application.Features.EventMoods.Query.GetAsPage;
using EventPlatform.Application.Features.EventMoods.Query.GetById;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.WebApi.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventPlatform.WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EventMoodsController(IMediator mediator) : ControllerApiBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetEventMoodsQuery(), ct));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new GetEventMoodByIdQuery() { Id = id }, ct));
        }

        [HttpGet("page")]
        public async Task<IActionResult> GetAsPage([FromQuery] Pageable page, CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetEventMoodsAsPageQuery() { Page = page }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEventMoodCommand request, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(request, ct));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, EventMoodUpdateDto dto, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new UpdateEventMoodByIdCommand() { Id = id, Entity = dto }, ct));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new DeleteEventMoodByIdCommand() { Id = id }, ct));
        }
    }
}
