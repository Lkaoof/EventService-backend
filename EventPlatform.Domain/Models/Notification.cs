using EventPlatform.Domain.Commnon;

namespace EventPlatform.Domain.Models
{
    public class Notification : BaseEntity
    {
        //public Guid Id { get; set; }

        public string Subject { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public NotificationType Type { get; set; }

        // Relations
        public Guid UserId { get; set; }

        public User User { get; set; } = null!;
    }
}
