using EventPlatform.Application.Features.UserTickets.Command.Create;
using EventPlatform.Application.Features.UserTickets.Command.DeleteById;
using EventPlatform.Application.Features.UserTickets.Command.UpdateById;
using EventPlatform.Application.Features.UserTickets.Query.Get;
using EventPlatform.Application.Features.UserTickets.Query.GetAsPage;
using EventPlatform.Application.Features.UserTickets.Query.GetById;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.WebApi.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPlatform.WebApi.Controllers.Basic
{
    //[Authorize(Roles = "Admin")]
    //[ApiController]
    //[Route("/api/[controller]")]
    public class UserTicketsController(IMediator mediator) : ControllerApiBase
    {
        //[HttpGet]
        //public async Task<IActionResult> GetAll(CancellationToken ct)
        //{
        //    return Ok(await mediator.Send(new GetUserTicketsQuery(), ct));
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        //{
        //    return ToActionResult(await mediator.Send(new GetUserTicketByIdQuery() { Id = id }, ct));
        //}

        //[HttpGet("page")]
        //public async Task<IActionResult> GetAsPage([FromQuery] Pageable page, CancellationToken ct)
        //{
        //    return Ok(await mediator.Send(new GetUserTicketsAsPageQuery() { Page = page }));
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(CreateUserTicketCommand request, CancellationToken ct)
        //{
        //    return ToActionResult(await mediator.Send(request, ct));
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(Guid id, UserTicketUpdateDto dto, CancellationToken ct)
        //{
        //    return ToActionResult(await mediator.Send(new UpdateUserTicketCommand() { Id = id, Entity = dto }, ct));
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        //{
        //    return ToActionResult(await mediator.Send(new DeleteUserTicketCommand() { Id = id }, ct));
        //}
    }
}
