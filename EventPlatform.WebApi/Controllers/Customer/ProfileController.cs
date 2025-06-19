using EventPlatform.Application.Features.Auth.Query.GetIdentityByEmail;
using EventPlatform.Application.Features.Users.Command.DeleteById;
using EventPlatform.Application.Features.Users.Command.UpdateById;
using EventPlatform.Application.Features.Users.Query.GetById;
using EventPlatform.Application.Features.Users.Query.GetEvents;
using EventPlatform.Application.Features.Users.Query.GetNotifications;
using EventPlatform.Application.Features.Users.Query.GetTickets;
using EventPlatform.WebApi.Common;
using EventPlatform.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPlatform.WebApi.Controllers.Customer
{
    [Authorize]
    [Tags("Users")]
    [ApiController]
    [Route("/api/users/profile")]
    public class ProfileController(IMediator mediator) : ControllerApiBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProfile(CancellationToken ct)
        {
            // Профиль пользователя: email, name, birthdate, avatar, phonenumber, edit_date,
            return ToActionResult(await mediator.Send(new GetUserByIdQuery() { Id = User.Id() }, ct));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(CancellationToken ct)
        {
            // TODO: удаление аккаунта, с подтверждением через почту
            return ToActionResult(await mediator.Send(new DeleteUserByIdCommand() { Id = User.Id() }, ct));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserUpdateDto user, CancellationToken ct)
        {
            // TODO: изменение аккаунта, с подтверждением через почту
            return ToActionResult(await mediator.Send(new UpdateUserCommand() { Id = User.Id(), User = user }, ct));
        }

        [HttpGet("events")]
        public async Task<IActionResult> GetEvents(CancellationToken ct)
        {
            // Организованные мероприятия: EventDto
            return Ok(await mediator.Send(new GetUsersEventsQuery() { UserId = User.Id() }));
        }

        [HttpGet("tickets")]
        public async Task<IActionResult> GetTickets(CancellationToken ct)
        {
            // Купленные билеты: TicketDto
            return Ok(await mediator.Send(new GetUsersTicketsQuery() { UserId = User.Id() }));
        }

        [HttpGet("notifications")]
        public async Task<IActionResult> GetNotifications(CancellationToken ct)
        {
            // Полученные ранее уведомленения (история уведомлений)
            return Ok(await mediator.Send(new GetUsersNotificationsQuery() { UserId = User.Id() }));
        }


    }
}
