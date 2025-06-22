using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Application.Models.Domain.Purchases;
using MediatR;

namespace EventPlatform.Application.Features.Purchases.Query.GetAsPage
{
    public class GetPurchasesAsPageQuery : IRequest<Page<PurchaseDto>>, ICacheable
    {
        public Guid UserId { get; set; }
        public Pageable Page { get; set; }
        public string CacheKey => $"purchases:page:{Page.Index},{Page.Size}";
    }
}
