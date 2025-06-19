using EventPlatform.Application.Features.Roles.Command.Create;
using EventPlatform.Application.Features.Roles.Command.DeleteById;
using EventPlatform.Application.Features.Roles.Command.UpdateById;
using EventPlatform.Application.Features.Roles.Query.Get;
using EventPlatform.Application.Features.Roles.Query.GetAsPage;
using EventPlatform.Application.Features.Roles.Query.GetById;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.WebApi.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPlatform.WebApi.Controllers.Basic
{
    [Tags("Admin")]
    [Authorize(Roles ="Admin")]
    [ApiController]
    [Route("/api/roles")]
    public class RolesController(IMediator mediator) : ControllerApiBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetRolesQuery(), ct));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new GetRoleByIdQuery() { Id = id }, ct));
        }

        [HttpGet("page")]
        public async Task<IActionResult> GetAsPage([FromQuery] Pageable page, CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetRolesAsPageQuery() { Page = page }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleCommand request, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(request, ct));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, RoleUpdateDto dto, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new UpdateRoleByIdCommand() { Id = id, Entity = dto }, ct));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new DeleteRoleByIdCommand() { Id = id }, ct));
        }

    }
}
