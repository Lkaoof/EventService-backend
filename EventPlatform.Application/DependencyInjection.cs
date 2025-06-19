using System.Reflection;
using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ValidationBehavior;
using EventPlatform.Application.Features.Common;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Services;
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

            services.AddScoped<IActions, Actions>();

            services.AddScoped<ITokenService, TokenService>();

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CacheBehavior<,>));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CacheInvalidateBehavior<,>));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]);

            return services;
        }
    }
}
