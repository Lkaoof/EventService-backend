using System.Reflection;
using AppAny.Quartz.EntityFrameworkCore.Migrations;
using AppAny.Quartz.EntityFrameworkCore.Migrations.PostgreSQL;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlatform.Database
{
    public class AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : DbContext(options), IDatabaseContext
    {
        // Identity
        public DbSet<User> Users { get; set; }

        // Application
        public DbSet<Event> Events { get; set; }

        public DbSet<Tag> EventTags { get; set; }

        public DbSet<EventMood> EventMoods { get; set; }

        public DbSet<EventType> EventTypes { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<UserTicket> UsersTickets { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnModelCreating(ModelBuilder models)
        {
            models.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            models.AddQuartz(builder =>
            {
                builder.UsePostgreSql();
            });

        }
    }
}
