using System.Text.Json.Serialization;
using EventPlatform.Domain.Commnon;

namespace EventPlatform.Domain.Models
{
    public class RefreshToken : BaseEntity
    {
        //public Guid Id { get; set; }

        public string Token { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime ExpiresAt { get; set; }

        public DateTime? RevokedAt { get; set; }

        [JsonIgnore]
        public bool IsActive { get => RevokedAt == null; }


        [JsonIgnore]
        public User User { get; set; } = null!;

        public Guid UserId { get; set; }

    }
}
