using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Features.Auth.Query.GetIdentityByEmail;
using EventPlatform.Application.Features.Auth.Query.GetIdentityById;
using EventPlatform.Application.Features.Auth.Query.GetIdentityByUsername;
using EventPlatform.Application.Features.Users.Command.Create;
using EventPlatform.Application.Features.Users.Command.SendConfirmationCode;
using EventPlatform.Application.Features.Users.Command.VerifyConfirmationCode;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Domain.Users;
using EventPlatform.WebApi.Common;
using EventPlatform.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EventPlatform.WebApi.Controllers.Auth
{
    [ApiController]
    [Route("/api/auth")]
    public class AuthController(IMediator mediator, IJwtProvider jwtProvider, IPasswordHasher passwordHasher, ITokenService tokenService) : ControllerApiBase
    {
        private CookieOptions _cookieOptions => new()
        {
            Path = "/api/Auth",
            Expires = DateTime.UtcNow.AddDays(15),
            HttpOnly = true,
            SameSite = SameSiteMode.Lax,
            Secure = false,
        };

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto reqwest, CancellationToken ct)
        {
            var refreshToken = Request.Cookies[jwtProvider.CookieName];

            if (!string.IsNullOrEmpty(refreshToken))
            {
                var isTokenValid = await jwtProvider.ValidateRefreshToken(refreshToken, ct);
                if (isTokenValid) return BadRequest("Токен ещё действует");
            }

            Result<UserIdentity> identity = null!;

            if (reqwest.LoginType is LoginType.Username)
            {
                identity = await mediator.Send(new GetIdentityByUsernameQuery() { Username = reqwest.Login }, ct);
            }
            if (reqwest.LoginType is LoginType.Email)
            {
                identity = await mediator.Send(new GetIdentityByEmailQuery() { Email = reqwest.Login }, ct);
            }

            if (identity.IsFailure)
            {
                return ToActionResult(identity);
            }

            var user = identity.Value!;
            var isPasswordEqual = passwordHasher.Verify(reqwest.Password, user.PasswordHash);
            if (!isPasswordEqual)
            {
                return Unauthorized(reqwest.Login);
            }

            var tokens = await jwtProvider.GenerateTokensAsync(user, ct);
            Response.Cookies.Append(jwtProvider.CookieName, tokens.refreshToken, _cookieOptions);

            return Ok(new { AccessToken = tokens.accessToken });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(CancellationToken ct)
        {
            var refreshToken = Request.Cookies[jwtProvider.CookieName];

            if (string.IsNullOrEmpty(refreshToken))
            {
                return Unauthorized("Отсутствует refresh токен");
            }

            await jwtProvider.RevokeUserTokenAsync(refreshToken, ct);
            Response.Cookies.Delete(jwtProvider.CookieName, _cookieOptions);

            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserCommand reqwest, CancellationToken ct)
        {
            var result = await mediator.Send(new GetIdentityByEmailQuery() { Email = reqwest.Email }, ct);
            if (result.IsSuccess)
            {
                return Conflict(reqwest.Name);
            }

            var verification = await mediator.Send(new VerifyConfirmationCodeCommand() { Code = reqwest.ConfirmationCode, Email = reqwest.Email }, ct);
            if (verification.IsFailure)
            {
                return ToActionResult(verification);
            }

            var newUser = await mediator.Send(reqwest, ct);
            if (newUser.IsFailure)
            {
                return ToActionResult(newUser);
            }

            return Created();
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshTokens(CancellationToken ct)
        {
            var refreshToken = Request.Cookies[jwtProvider.CookieName];

            if (string.IsNullOrEmpty(refreshToken))
            {
                return Unauthorized("Отсутствует refresh токен");
            }

            Response.Cookies.Delete(jwtProvider.CookieName, _cookieOptions);

            Guid userId;
            try
            {
                userId = await jwtProvider.GetUserIdByRefreshTokenAsync(refreshToken, ct);
            }
            catch (SecurityTokenException ex)
            {
                return Unauthorized(ex.Message);
            }

            var result = await mediator.Send(new GetIdentityByIdQuery() { Id = userId }, ct);

            if (result.IsFailure)
            {
                return NotFound(refreshToken);
            }

            await jwtProvider.RevokeUserTokenAsync(refreshToken, ct);
            var tokens = await jwtProvider.GenerateTokensAsync(result.Value!, ct);

            Response.Cookies.Append(jwtProvider.CookieName, tokens.refreshToken, _cookieOptions);

            return Ok(new { AccessToken = tokens.accessToken });
        }

        [Authorize]
        [HttpPost("logout/all")]
        public async Task<IActionResult> LogoutFromAll(CancellationToken ct)
        {
            await jwtProvider.RevokeAllUserTokensAsync(User.Id(), ct);
            Response.Cookies.Delete(jwtProvider.CookieName, _cookieOptions);
            return Ok();
        }

        [Authorize]
        [HttpPost("logout/{sessionId}")]
        public async Task<IActionResult> RevokeActiveSession(Guid sessionId, CancellationToken ct)
        {
            var token = await tokenService.GetActiveTokenByIdAsync(sessionId, ct);

            if (token == null)
            {
                return BadRequest(sessionId);
            }

            await tokenService.RevokeTokenAsync(token, ct);
            return Ok();
        }

        [Authorize]
        [HttpGet("sessions")]
        public async Task<IActionResult> GetActiveSessions(CancellationToken ct)
        {
            return Ok(tokenService.GetActiveTokensByUserIdAsync(User.Id(), ct));
        }

        [HttpPost("confirm")]
        public async Task<IActionResult> SendConfirmationCode([FromQuery] string email, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new SendConfirmationCodeCommand() { Email = email }, ct));
        }

        //[HttpGet("verify")]
        //public async Task<IActionResult> VerifyConfirmationCode(string code, CancellationToken ct)
        //{
        //    return ToActionResult(await mediator.Send(new VerifyConfirmationCodeCommand() { Code = code }, ct));
        //}

        //[HttpPost("send-mail")]
        //public async Task<IActionResult> SendImail(string email, string subject, string content, CancellationToken ct)
        //{
        //    //await _emailSender.SendAsync(email, subject, content, ct);
        //    await jobScheduler.ScheduleEmailSend(DateTimeOffset.Now.Add(TimeSpan.FromSeconds(10)), email, subject, content, ct);
        //    //await _jobScheduler.ScheduleAwait(DateTimeOffset.Now.Add(TimeSpan.FromSeconds(5)), Guid.NewGuid(), Guid.NewGuid());
        //    return Ok("Sended!");
        //}

        //[HttpGet("job")]
        //public async Task<IActionResult> ScheduleJob(CancellationToken ct)
        //{
        //    return Ok("Nothing");
        //}
    }
}
