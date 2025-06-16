using EventPlatform.Application.Features.Users.Command.CreateUser;
using EventPlatform.Application.Features.Users.Command.DeleteUserById;
using EventPlatform.Application.Features.Users.Command.SendConfirmationCode;
using EventPlatform.Application.Features.Users.Command.UpdateUserById;
using EventPlatform.Application.Features.Users.Command.VerifyConfirmationCode;
using EventPlatform.Application.Features.Users.Query.GetUserById;
using EventPlatform.Application.Features.Users.Query.GetUsers;
using EventPlatform.Application.Features.Users.Query.GetUsersAsPage;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.RandomCodeGeneration;
using EventPlatform.WebApi.Common;
using EventPlatform.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventPlatform.WebApi.Controllers
{

    [ApiController]
    [Route("/[controller]")]
    public class UsersController(IMediator mediator, IEmailSender emailSender, IQuartzJobScheduler jobScheduler, IRandomCodeGeneration codeGenerator) : ControllerApiBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetUsersQuery(), ct));
        }

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

        [HttpPost("send-mail")]
        public async Task<IActionResult> SendImail(string email, string subject, string content, CancellationToken ct)
        {
            //await _emailSender.SendAsync(email, subject, content, ct);
            await jobScheduler.ScheduleEmailSend(DateTimeOffset.Now.Add(TimeSpan.FromSeconds(10)), email, subject, content, ct);
            //await _jobScheduler.ScheduleAwait(DateTimeOffset.Now.Add(TimeSpan.FromSeconds(5)), Guid.NewGuid(), Guid.NewGuid());
            return Ok("Sended!");
        }

        [HttpGet("job")]
        public async Task<IActionResult> ScheduleJob(CancellationToken ct)
        {
            return Ok("Nothing");
        }

        [HttpPost("SendConfirmationCode")]
        public async Task<IActionResult> SendConfirmationCode([FromQuery] string email, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new SendConfirmationCodeCommand() { Email = email, UserId = new Guid("9D2B0228-4D0D-4C23-8B49-01A698857709") }, ct));
        }

        [HttpGet("VerifyConfirmationCode")]
        public async Task<IActionResult> VerifyConfirmationCode(string code, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new VerifyConfirmationCodeCommand() {Code = code, UserId = new Guid("9D2B0228-4D0D-4C23-8B49-01A698857709") }, ct));
        }
    }
}
