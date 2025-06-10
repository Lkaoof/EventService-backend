namespace EventPlatform.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public DateTime Birthdate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime LastUpdatedAt { get; set; } = DateTime.Now;

        public DateTime PasswordUpdatedAt { get; set; } = DateTime.Now;


        // Relations
        public ICollection<Role> Roles { get; set; } = [];

        public ICollection<Event> Events { get; set; } = [];

        public ICollection<UserTicket> Tickets { get; set; } = [];

        public ICollection<Notification> Notifications { get; set; } = [];

        public ICollection<RefreshToken> RefreshTokens { get; set; } = [];
    }
}
