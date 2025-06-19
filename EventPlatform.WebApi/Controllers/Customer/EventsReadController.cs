using EventPlatform.Application.Features.Events.Query.Get;
using EventPlatform.Application.Features.Events.Query.GetAsPage;
using EventPlatform.Application.Features.Events.Query.GetById;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.WebApi.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPlatform.WebApi.Controllers.Customer
{
    [Tags("Events")]
    [Authorize]
    [ApiController]
    [Route("/api/events")]
    public class EventsReadController(IMediator mediator) : ControllerApiBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetEventsQuery(), ct));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new GetEventByIdQuery() { Id = id }, ct));
        }

        [HttpGet("page")]
        public async Task<IActionResult> GetAsPage([FromQuery] Pageable page, CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetEventAsPageQuery() { Page = page }));
        }
    }
}
