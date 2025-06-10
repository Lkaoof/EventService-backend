using EventPlatform.Application.Interfaces.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventPlatform.Database
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["Database:Connection"]
                ?? throw new ArgumentNullException(nameof(configuration), "Database connection is missing in configuration.");

            services.AddDbContext<PostgresDatabaseContext>(options =>
            {
                options.UseNpgsql(connectionString, options => options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
                //options.UseInMemoryDatabase("testdb");
            });

            services.AddScoped<IDatabaseContext>(provider =>
            {
                return provider.GetRequiredService<PostgresDatabaseContext>();
            });

            return services;
        }
    }
}
