using EventPlatform.Domain.Commnon;

namespace EventPlatform.Domain.Models
{
    public class Role : BaseEntity
    {
        //public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool isPublic { get; set; }

        // Relations
        public ICollection<User> Users { get; set; } = [];
    }
}
