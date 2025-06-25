using EventPlatform.Notifications.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventPlatform.Notifications
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddNotificationHub(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IConnectionTracker, ConnectionTracker>();

            return services;
        }
    }
}
