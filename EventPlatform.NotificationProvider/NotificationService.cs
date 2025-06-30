using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Domain.Notifications;
using EventPlatform.Notifications.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace EventPlatform.Notifications
{
    public class NotificationService(IHubContext<NotificationHub> hubContext, IConnectionTracker tracker, IDatabaseContext dbContext) : INotificationService
    {
        public async Task SendNotificationAsync(NotificationDto notification)
        {
            var userIdString = notification.UserId.ToString();
            if (await tracker.IsUserConnected(userIdString))
            {
                await hubContext.Clients.Group(userIdString).SendAsync("ReceiveNotification", notification);
            }
        }
    }
}
