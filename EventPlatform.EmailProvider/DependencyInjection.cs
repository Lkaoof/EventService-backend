using EventPlatform.Application.Interfaces.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventPlatform.Email
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEmailSender(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmailSender, EmailSender>();
            return services;
        }
    }
}
