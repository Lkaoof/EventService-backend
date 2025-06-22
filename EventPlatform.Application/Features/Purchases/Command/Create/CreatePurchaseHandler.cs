using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.Purchases;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Purchases.Command.Create
{
    public class CreatePurchaseHandler(IActions actions) : IRequestHandler<CreatePurchaseCommand, Result<PurchaseDto>>
    {
        public async Task<Result<PurchaseDto>> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
        {
            return await actions.Create<Purchase, PurchaseDto>(request.Entity, cancellationToken);
        }
    }
}
