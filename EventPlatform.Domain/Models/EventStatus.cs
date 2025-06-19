namespace EventPlatform.Domain.Models
{
    [Flags]
    public enum EventStatus
    {
        Rejected,
        Approved,
        UnderModeration,
        Finished
    }
}
