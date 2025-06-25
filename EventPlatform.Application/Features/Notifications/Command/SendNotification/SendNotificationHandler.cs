using EventPlatform.Notifications;
using MediatR;

namespace EventPlatform.Application.Features.Notifications.Command.SendNotification
{
    public class SendNotificationHandler(INotificationService notificationService) : IRequestHandler<SendNotificationCommand>
    {
        public async Task Handle(SendNotificationCommand request, CancellationToken cancellationToken)
        {
            await notificationService.SendNotificationAsync(request.Notification);
        }
    }
}
