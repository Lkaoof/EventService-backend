using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Purchases;
using MediatR;

namespace EventPlatform.Application.Features.Purchases.Query.GetById
{
    public class GetPurchaseByIdQuery : IRequest<Result<PurchaseDto>>, ICacheable
    {
        public Guid Id { get; set; }

        public string CacheKey => $"purchase:{Id}";
    }
}
