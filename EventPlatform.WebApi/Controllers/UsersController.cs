using EventPlatform.Application.Features.Users.Command.CreateUser;
using EventPlatform.Application.Features.Users.Command.DeleteUserById;
using EventPlatform.Application.Features.Users.Command.UpdateUserById;
using EventPlatform.Application.Features.Users.Query.GetUserById;
using EventPlatform.Application.Features.Users.Query.GetUsers;
using EventPlatform.Application.Features.Users.Query.GetUsersAsPage;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.RandomCodeGeneration;
using EventPlatform.WebApi.Common;
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

        [HttpGet("SendConfirmationCode")]
        public async Task<IActionResult> SendConfirmationCode([FromQuery] string email, CancellationToken ct)
        {
            //Миша добавил простейшую валидацию чтобы с пустым полем не робило какую нашел в интернете если нужна другая и эта мазолит тебе глаза не меняй я сам разберусь и сделаю чето другое
            if (string.IsNullOrWhiteSpace(email))
                return BadRequest("Email is required");

            string code = codeGenerator.GenerateRandomCode(6, true, true);

            string subject = "Код подтверждения";
            string content = $"{code}";

            await jobScheduler.ScheduleEmailSend(DateTimeOffset.Now.AddSeconds(6), email, subject, content, ct);

            return Ok(code);
            //return Ok("Sended!");

        }
    }
}
