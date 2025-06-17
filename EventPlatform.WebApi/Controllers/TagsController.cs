using EventPlatform.Application.Features.Tags.Command.Create;
using EventPlatform.Application.Features.Tags.Command.DeleteById;
using EventPlatform.Application.Features.Tags.Command.UdpateById;
using EventPlatform.Application.Features.Tags.Query.Get;
using EventPlatform.Application.Features.Tags.Query.GetAsPage;
using EventPlatform.Application.Features.Tags.Query.GetById;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.WebApi.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventPlatform.WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TagsController(IMediator mediator) : ControllerApiBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetTagsQuery(), ct));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new GetTagByIdQuery() { Id = id }, ct));
        }

        [HttpGet("page")]
        public async Task<IActionResult> GetAsPage([FromQuery] Pageable page, CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetTagsAsPageQuery() { Page = page }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTagCommand request, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(request, ct));
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
