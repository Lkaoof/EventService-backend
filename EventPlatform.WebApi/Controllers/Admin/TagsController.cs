using EventPlatform.Application.Features.Tags.Command.Create;
using EventPlatform.Application.Features.Tags.Command.DeleteById;
using EventPlatform.Application.Features.Tags.Command.UdpateById;
using EventPlatform.Application.Models.Domain.Tags;
using EventPlatform.WebApi.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPlatform.WebApi.Controllers.Admin
{
    [Tags("Admin")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("/api/tags")]
    public class TagsController(IMediator mediator) : ControllerApiBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(TagCreateDto enity, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new CreateTagCommand() { Entity = enity }, ct));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, TagUpdateDto dto, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new UpdateTagByIdCommand() { Id = id, Entity = dto }, ct));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new DeleteTagByIdCommand() { Id = id }, ct));
        }
    }
}
