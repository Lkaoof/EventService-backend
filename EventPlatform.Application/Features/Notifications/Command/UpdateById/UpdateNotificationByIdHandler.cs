using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.Notifications;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Notifications.Command.UpdateById
{
    public class UpdateNotificationByIdHandler(IActions actions) : IRequestHandler<UpdateNotificationByIdCommand
        , Result<NotificationDto>>
    {
        public async Task<Result<NotificationDto>> Handle(UpdateNotificationByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.Update<Notification, NotificationDto>(request.Id, request.Entity, cancellationToken);
        }
    }
}
