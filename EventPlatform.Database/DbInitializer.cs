using EventPlatform.Domain.Models;

namespace EventPlatform.Database
{
    public static class DbInitializer
    {
        public static void Initialize(PostgresDatabaseContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any()) return;

            var now = DateTime.UtcNow;

            var user = new User
            {
                Birthdate = now,
                CreatedAt = now,
                Email = "test@test.com",
                PhoneNumber = "1234567890",
                LastUpdatedAt = now,
                Name = "Test",
                PasswordHash = "123123123123123",
                PasswordUpdatedAt = now,
            };

            context.Users.Add(user);

            context.SaveChanges();
        }
    }
}
