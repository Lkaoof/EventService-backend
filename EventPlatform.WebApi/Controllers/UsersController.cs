using EventPlatform.Application.Features.Users.Command.DeleteUserById;
using EventPlatform.Application.Features.Users.Query.GetUsers;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Pagination;
using EventPlatform.WebApi.Common;
using MediatR;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using EventPlatform.RandomCodeGeneration;

namespace EventPlatform.WebApi.Controllers
{

    [ApiController]
    [Route("/[controller]")]
    public class UsersController : ControllerApiBase
    {
        private readonly ICache _cache;
        private readonly IMediator _mediator;
        private readonly IDatabaseContext _db;
        private readonly IEmailSender _emailSender;
        private readonly IQuartzJobScheduler _jobScheduler;
        private readonly IRandomCodeGeneration _codeGenerator;

        public UsersController(ICache cache, IMediator mediator, IDatabaseContext db, IEmailSender emailSender, IQuartzJobScheduler jobScheduler, IRandomCodeGeneration codeGenerator)
        {
            _cache = cache;
            _mediator = mediator;
            _db = db;
            _emailSender = emailSender;
            _jobScheduler = jobScheduler;
            _codeGenerator = codeGenerator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers(CancellationToken ct)
        {
            return Ok(await _mediator.Send(new GetUsersQuery()));
        }

        [HttpGet("page")]
        public async Task<IActionResult> GetUsersAsPage([FromQuery] Pageable page, CancellationToken ct)
        {
            return Ok();
        }

        [HttpGet("metadata")]
        public async Task<IActionResult> GetUsersMetadata(CancellationToken ct)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id, CancellationToken ct)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DropUser(Guid id, CancellationToken ct)
        {
            //await _userService.DeleteUserById(id, ct);
            await _mediator.Send(new DeleteUserByIdCommand() { Id = id }, ct);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SendImail(string email, string subject, string content, CancellationToken ct)
        {
            //await _emailSender.SendAsync(email, subject, content, ct);
            await _jobScheduler.ScheduleEmailSend(DateTimeOffset.Now.Add(TimeSpan.FromSeconds(10)), email, subject, content, ct);
            //await _jobScheduler.ScheduleAwait(DateTimeOffset.Now.Add(TimeSpan.FromSeconds(5)), Guid.NewGuid(), Guid.NewGuid());
            return Ok("Sended!");
        }

        [HttpGet("job")]
        public async Task<IActionResult> ScheduleJob(CancellationToken ct)
        {
            return Ok();
        }
        [HttpGet("SendConfirmationCode")]
        public async Task<IActionResult> SendConfirmationCode([FromQuery] string email, CancellationToken ct)
        {
            if (string.IsNullOrWhiteSpace(email))
                return BadRequest("Email is required");
           
            string code = _codeGenerator.GenerateRandomCode(6, true,true);
           
            string subject = "Код подтверждения";
            string content = $"{code}";

            await _jobScheduler.ScheduleEmailSend(DateTimeOffset.Now.AddSeconds(6), email, subject, content, ct);

            return Ok(code);
            //return Ok("Sended!");

        }
    }
}
