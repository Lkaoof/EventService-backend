using EventPlatform.WebApi.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPlatform.WebApi.Controllers.Admin
{
    [Tags("Admin")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("/api/notifications")]
    public class NotificationsController(IMediator mediator) : ControllerApiBase
    {
        //[HttpGet]
        //public async Task<IActionResult> GetAll(CancellationToken ct)
        //{
        //    return Ok(await mediator.Send(new GetNotificationsQuery(), ct));
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        //{
        //    return ToActionResult(await mediator.Send(new GetNotificationByIdQuery() { Id = id }, ct));
        //}

        //[HttpGet("page")]
        //public async Task<IActionResult> GetAsPage([FromQuery] Pageable page, CancellationToken ct)
        //{
        //    return Ok(await mediator.Send(new GetNotificationsAsPageQuery() { Page = page }));
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(CreateNotificationCommand request, CancellationToken ct)
        //{
        //    return ToActionResult(await mediator.Send(request, ct));
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(Guid id, NotificationUpdateDto dto, CancellationToken ct)
        //{
        //    return ToActionResult(await mediator.Send(new UpdateNotificationByIdCommand() { Id = id, Entity = dto }, ct));
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        //{
        //    return ToActionResult(await mediator.Send(new DeleteNotificationByIdCommand() { Id = id }, ct));
        //}
    }
}
