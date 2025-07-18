﻿using System.Text;
using System.Text.Json.Serialization;
using EventPlatform.Application;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.BackgroundScheduller;
using EventPlatform.Cache;
using EventPlatform.Database;
using EventPlatform.Email;
using EventPlatform.Jwt;
using EventPlatform.Notifications;
using EventPlatform.PasswordHash;
using EventPlatform.Payments;
using EventPlatform.RandomCodeGeneration;
using EventPlatform.WebApi.Common;
using EventPlatform.WebApi.Initializers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;


var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var config = builder.Configuration;

services.AddControllers(opt =>
{
    opt.Filters.Add<ExceptionFilter>();
})
.AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

services.AddSignalR(options =>
{
    options.KeepAliveInterval = TimeSpan.FromSeconds(15);
    options.ClientTimeoutInterval = TimeSpan.FromSeconds(30);
});
services.AddOpenApi();
services.AddEndpointsApiExplorer();
services.AddCodeGeneration(config);
services.AddContext(config);
services.AddCache(config);
services.AddEmailSender(config);
services.AddBackgroundScheduler(config);
services.AddApplication(config);
services.AddJwtProvider(config);
services.AddPasswordHasher(config);
services.AddPayments(config);
services.AddNotificationHub(config);

var JwtOptions = config.GetSection("JwtOptions");
services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
        {
            opt.SaveToken = true;
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
                    var path = context.HttpContext.Request.Path;
                    if (path.StartsWithSegments("/hub/notifications"))
                    {
                        context.Token = context.Request.Query["access_token"];
                        return Task.CompletedTask;
                    }

                    string token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last() ?? string.Empty;

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

//services.AddCors(options =>
//{
//    options.AddPolicy("AllowSpecificOrigins", builder =>
//    {
//        builder.WithOrigins("http://localhost:5500")
//               .AllowAnyHeader()
//               .AllowAnyMethod()
//               .AllowCredentials();
//    });
//});


var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowSpecificOrigins");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapHub<NotificationHub>("/hub/notifications");
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<IDatabaseContext>();
        ((DbContext)context).Database.Migrate();

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
        //c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
        c.InjectStylesheet("/swagger-ui/Swagger.css");
        c.InjectJavascript("/swagger-ui/SwaggerScript.js");
        c.DisplayRequestDuration();
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = string.Empty;
        c.DocExpansion(DocExpansion.None);
    });
    app.MapOpenApi();
}

app.Run();