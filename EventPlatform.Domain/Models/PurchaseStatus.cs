namespace EventPlatform.Domain.Models
{
    [Flags]
    public enum PurchaseStatus
    {
        Pending,
        Success,
        Cancelled,
    }
}
