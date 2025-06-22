using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.Purchases
{
    public class PurchaseCreateDto : IMapWith<Purchase>
    {
        public string ProductUrl { get; set; }
        public string BillUrl { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public PurchaseStatus Status { get; set; } = PurchaseStatus.Pending;
        public Guid CustomerId { get; set; }
    }
}
