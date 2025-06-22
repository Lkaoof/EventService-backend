using EventPlatform.Application.Common.CacheBehavior;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Models.Domain.Purchases;
using MediatR;

namespace EventPlatform.Application.Features.Purchases.Command.UpdateById
{
    public class UpdatePurchaseByIdCommand : IRequest<Result<PurchaseDto>>, ICacheInvalidate
    {
        public Guid Id { get; set; }

        public PurchaseUpdateDto Entity { get; set; }

        public string[] CacheKeys => [$"purchase:{Id}", "purchases*"];
    }
}
