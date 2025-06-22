using EventPlatform.Application.Interfaces.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventPlatform.Payments
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPayments(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IPaymentsProvider, MockPaymentsProvider>();
            return services;
        }
    }
}
