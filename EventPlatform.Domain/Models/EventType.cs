using EventPlatform.Domain.Commnon;

namespace EventPlatform.Domain.Models
{
    public class EventType : BaseEntity
    {
        //public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public bool IsAvailable { get; set; } = true;


        // Relations 
        public ICollection<Event> Events { get; set; } = [];
    }
}
