using EventPlatform.Application.Features.Users.Command.Create;
using EventPlatform.Application.Features.Users.Command.DeleteById;
using EventPlatform.Application.Features.Users.Command.SendConfirmationCode;
using EventPlatform.Application.Features.Users.Command.UpdateById;
using EventPlatform.Application.Features.Users.Command.VerifyConfirmationCode;
using EventPlatform.Application.Features.Users.Query.Get;
using EventPlatform.Application.Features.Users.Query.GetAsPage;
using EventPlatform.Application.Features.Users.Query.GetById;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.WebApi.Common;
using EventPlatform.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPlatform.WebApi.Controllers.Basic
{
    [Tags("Admin")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("/api/users")]
    public class UsersController(IMediator mediator, IEmailSender emailSender, IQuartzJobScheduler jobScheduler, IRandomCodeGeneration codeGenerator) : ControllerApiBase
    {
        //[HttpGet]
        //public async Task<IActionResult> GetAll(CancellationToken ct)
        //{
        //    return Ok(await mediator.Send(new GetUsersQuery(), ct));
        //}

        [HttpGet("page")]
        public async Task<IActionResult> GetAsPage([FromQuery] Pageable page, CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetUsersAsPageQuery() { Page = page }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new GetUserByIdQuery() { Id = id }, ct));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new DeleteUserByIdCommand() { Id = id }, ct));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, UserUpdateDto user, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new UpdateUserCommand() { Id = id, User = user }, ct));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand request, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(request, ct));
        }
    }
}
