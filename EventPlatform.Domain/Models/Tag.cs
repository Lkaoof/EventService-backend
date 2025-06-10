namespace EventPlatform.Domain.Models
{
    public class Tag
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;


        // Relations 
        public ICollection<Event> Events { get; set; } = [];
    }
}
