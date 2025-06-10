using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Pagination;
using EventPlatform.BackgroundScheduller;
using EventPlatform.EmailProvider;
using EventPlatform.WebApi.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventPlatform.WebApi.Controllers
{

    [ApiController]
    [Route("/[controller]")]
    public class UsersController : ControllerApiBase
    {
        private readonly IDatabaseContext _db;
        private readonly IEmailSender _emailSender;
        private readonly IQuartzJobScheduler _jobScheduler;
        private readonly IUserService _userService;

        public UsersController(IDatabaseContext db, IEmailSender emailSender, IQuartzJobScheduler jobScheduler, IUserService userService)
        {
            _db = db;
            _emailSender = emailSender;
            _jobScheduler = jobScheduler;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers(CancellationToken ct)
        {
            return Ok(await _db.Users.ToListAsync(ct));
        }

        [HttpGet("page")]
        public async Task<IActionResult> GetUsersAsPage([FromQuery] Pageable page, CancellationToken ct)
        {
            return Ok(await _userService.GetUsersAsPage(page, ct));
        }

        [HttpGet("metadata")]
        public async Task<IActionResult> GetUsersMetadata(CancellationToken ct)
        {
            return Ok(await _userService.GetUsersMetadata(ct));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id, CancellationToken ct)
        {
            return Ok(await _userService.GetUserById(id, ct));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DropUser(Guid id, CancellationToken ct)
        {
            await _userService.DeleteUserById(id, ct);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SendImail(string email, string subject, string content, CancellationToken ct)
        {
            //await _emailSender.SendAsync(email, subject, content, ct);
            //await _jobScheduler.ScheduleEmailSend(DateTimeOffset.Now.Add(TimeSpan.FromSeconds(5)), email, subject, content, ct);
            await _jobScheduler.ScheduleAwait(DateTimeOffset.Now.Add(TimeSpan.FromSeconds(5)), Guid.NewGuid(), Guid.NewGuid());
            return Ok("Sended!");
        }

        [HttpGet("job")]
        public async Task<IActionResult> ScheduleJob(CancellationToken ct)
        {
            return Ok();
        }
    }
}
