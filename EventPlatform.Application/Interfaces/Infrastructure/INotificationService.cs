using EventPlatform.Application.Models.Domain.Notifications;

namespace EventPlatform.Notifications
{
    public interface INotificationService
    {
        Task SendNotificationAsync(NotificationDto notification);
    }
}