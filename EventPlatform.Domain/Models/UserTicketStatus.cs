namespace EventPlatform.Domain.Models
{
    [Flags]
    public enum UserTicketStatus
    {
        Used,
        Active,
        Returned,
    }
}
