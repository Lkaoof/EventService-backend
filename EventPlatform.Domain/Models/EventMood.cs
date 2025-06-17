using EventPlatform.Domain.Commnon;

namespace EventPlatform.Domain.Models
{
    public class EventMood : BaseEntity
    {
        //public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;


        // Relations 
        public ICollection<Event> Events { get; set; } = [];
    }
}
