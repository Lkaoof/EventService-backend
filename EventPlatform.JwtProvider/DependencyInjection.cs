using EventPlatform.Application.Interfaces.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventPlatform.Jwt
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddJwtProvider(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IJwtProvider, JwtProvider>();
            return services;
        }
    }
}
