
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EventPlatform.Application;
using EventPlatform.BackgroundScheduller;
using EventPlatform.Cache;
using EventPlatform.Database;
using EventPlatform.Email;
using EventPlatform.WebApi;

var webApiConfiguration = (IServiceCollection services, IConfiguration config) =>
{

};

var api = new Api(args, webApiConfiguration);

await api.StartAsync((app) =>
{
    using (var scope = app.Services.CreateScope())
    {
        var serviceProvider = scope.ServiceProvider;
        try
        {
            var context = serviceProvider.GetRequiredService<PostgresDatabaseContext>();
            DbInitializer.Initialize(context);
        }
        catch (Exception)
        {
            throw;
        }
    }
});