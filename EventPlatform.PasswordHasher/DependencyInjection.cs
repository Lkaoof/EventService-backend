using EventPlatform.Application.Interfaces.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventPlatform.PasswordHash
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPasswordHasher(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            return services;
        }
    }
}
