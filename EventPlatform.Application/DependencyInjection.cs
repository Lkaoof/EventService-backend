using System.Reflection;
using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ValidationBehavior;
using EventPlatform.Application.Features.Common;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventPlatform.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            services.AddAutoMapper(typeof(DependencyInjection).Assembly);

            services.AddTransient<IActions, Actions>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheBehavior<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheInvalidateBehavior<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]);

            return services;
        }
    }
}
