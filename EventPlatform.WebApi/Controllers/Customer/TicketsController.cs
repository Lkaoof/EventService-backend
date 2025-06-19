using EventPlatform.Application.Features.Tickets.Command.Create;
using EventPlatform.Application.Features.Tickets.Command.DeleteById;
using EventPlatform.Application.Features.Tickets.Command.UpdateById;
using EventPlatform.Application.Features.Tickets.Query.Get;
using EventPlatform.Application.Features.Tickets.Query.GetAsPage;
using EventPlatform.Application.Features.Tickets.Query.GetById;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.WebApi.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPlatform.WebApi.Controllers.Customer
{
    [Authorize(Roles = "Organizer, Admin, Moderator")]
    [ApiController]
    [Route("/api/tickets")]
    public class TicketsController(IMediator mediator) : ControllerApiBase
    {
        //[HttpGet]
        //public async Task<IActionResult> GetAll(CancellationToken ct)
        //{
        //    return Ok(await mediator.Send(new GetTicketsQuery(), ct));
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new GetTicketByIdQuery() { Id = id }, ct));
        }

        [HttpGet("page")]
        public async Task<IActionResult> GetAsPage([FromQuery] Pageable page, CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetTicketsAsPageQuery() { Page = page }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTicketCommand request, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(request, ct));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, TicketUpdateDto dto, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new UpdateTicketCommand() { Id = id, Entity = dto }, ct));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new DeleteTicketCommand() { Id = id }, ct));
        }

    }
}
