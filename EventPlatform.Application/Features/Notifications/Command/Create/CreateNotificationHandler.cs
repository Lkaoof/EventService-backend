using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.Notifications;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Notifications.Command.Create
{
    public class CreateNotificationHandler(IActions actions) : IRequestHandler<CreateNotificationCommand, Result<NotificationDto>>
    {
        public async Task<Result<NotificationDto>> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            return await actions.Create<Notification, NotificationDto>(request, cancellationToken);
        }
    }
}
