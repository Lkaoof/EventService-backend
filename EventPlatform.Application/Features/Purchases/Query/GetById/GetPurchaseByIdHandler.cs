using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.Purchases;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Purchases.Query.GetById
{
    public class GetPurchaseByIdHandler(IActions actions) : IRequestHandler<GetPurchaseByIdQuery, Result<PurchaseDto>>
    {
        public async Task<Result<PurchaseDto>> Handle(GetPurchaseByIdQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetById<Purchase, PurchaseDto>(request.Id, cancellationToken);
        }
    }
}
