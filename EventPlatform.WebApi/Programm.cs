using System.Text;
using System.Text.Json.Serialization;
using EntityGraphQL.AspNet;
using EventPlatform.Application;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.BackgroundScheduller;
using EventPlatform.Cache;
using EventPlatform.Database;
using EventPlatform.Email;
using EventPlatform.Jwt;
using EventPlatform.PasswordHash;
using EventPlatform.Payments;
using EventPlatform.RandomCodeGeneration;
using EventPlatform.WebApi.Initializers;
using GraphQL.Server.Ui.Altair;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;


var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

services.AddCodeGeneration(config);
services.AddControllers()
.AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

services.AddOpenApi();
services.AddEndpointsApiExplorer();
services.AddGraphQLSchema<PostgresDatabaseContext>();
services.AddContext(config);
services.AddCache(config);
services.AddEmailSender(config);
services.AddBackgroundScheduler(config);
services.AddApplication(config);
services.AddJwtProvider(config);
services.AddPasswordHasher(config);
services.AddPayments(config);

var JwtOptions = config.GetSection("JwtOptions");
services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
        {
            opt.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = JwtOptions["Issuer"],
                ValidAudience = JwtOptions["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtOptions["SecretKey"]!)),
                ClockSkew = TimeSpan.Zero
            };

            opt.Events = new()
            {
                OnMessageReceived = context =>
                {
                    string token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last() ?? string.Empty;

                    //var token = context.Request.Cookies[JwtOptions["CookieName"] ?? "RefreshToken"];

                    if (!string.IsNullOrEmpty(token))
                    {
                        context.Token = token;
                    }

                    return Task.CompletedTask;
                }
            };
        });


services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "EventPlatform API ",
        Version = "v1",
        Description = "API for EventPlatform",
    });

    c.OrderActionsBy((apiDesc) => $"{apiDesc.RelativePath}_{apiDesc.HttpMethod}");

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header: Bearer {token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
{
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
});
});

services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", builder =>
    {
        // localhost:5500 - адрес, который находитс¤ в загроовке запроса "Origin".
        // в текущей конфигурации cookie same-site=lax, cookie будут передаватьс¤ в кросс-доменных запросах “ќЋ№ ќ при GET запросах.
        // например, если клиент запущен на localhost:5500 и сервер на localhost:5001, то cookie будут передаватьс¤ и при POST запросах.
        // если клиент запущен на 127.0.0.1:5500 и сервер на localhost:5001, то возникнет ошибка  CORS, т.к. 127.0.0.1:5500 != localhost:5500,
        // можно установить параметр same-site=none, тогда cookie будут передаватьс¤ на любой домен и при этом cookie должен иметь флаг secure,
        // если указать same-site=none без secure, браузер проигнорирует такой cookie.
        builder.WithOrigins("http://localhost:5500")
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials();
    });
});


var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowSpecificOrigins");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.MapGraphQL<PostgresDatabaseContext>();
app.MapGraphQLAltair(options: new AltairOptions
{
    GraphQLEndPoint = "/graphql",
});

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
        var exception = exceptionHandlerPathFeature?.Error;

        if (exception is Exception)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync($"An unexpected error occurred:{exception.Message}");
        }
    });
});

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<PostgresDatabaseContext>();
        context.Database.Migrate();

        var cache = serviceProvider.GetRequiredService<ICache>();
        await cache.RemoveKeysMask("*");

        DbInitializer.Initialize(context);
    }
    catch (Exception)
    {
        throw;
    }
}

Console.WriteLine($"Is Development: {app.Environment.IsDevelopment()}");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
        c.InjectJavascript("/swagger-ui/SwaggerScript.js");
        c.DisplayRequestDuration();
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = string.Empty;
        c.DocExpansion(DocExpansion.None);
    });
    app.MapOpenApi();
}

app.Run();