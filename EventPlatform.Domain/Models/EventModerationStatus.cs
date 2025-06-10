namespace EventPlatform.Domain.Models
{
    [Flags]
    public enum EventModerationStatus
    {
        Rejected,
        Approved,
        UnderModeration,
    }
}
