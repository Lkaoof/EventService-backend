using EventPlatform.Application.Common.Mapping;
using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Models.Domain.Purchases
{
    public class PurchaseUpdateDto : IMapWith<Purchase>
    {
        public string? ProductUrl { get; set; } = null!;
        public string? BillUrl { get; set; } = null!;
        public decimal? Amount { get; set; }
        public string? Description { get; set; }
    }
}
