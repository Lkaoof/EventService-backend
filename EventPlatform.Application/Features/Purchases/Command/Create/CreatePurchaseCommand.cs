using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Purchases;
using MediatR;

namespace EventPlatform.Application.Features.Purchases.Command.Create
{
    public class CreatePurchaseCommand : IRequest<Result<PurchaseDto>>, ICacheInvalidate
    {
        public PurchaseCreateDto Entity { get; set; }
        public string[] CacheKeys => ["purchases*"];
    }
}
