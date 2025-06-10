namespace EventPlatform.Domain.Models
{
    public class EventMood
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;


        // Relations 
        public ICollection<Event> Events { get; set; } = [];
    }
}
