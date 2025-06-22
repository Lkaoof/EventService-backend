using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.Purchases;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Purchases.Command.UpdateById
{
    public class UpdatePurchaseByIdHandler(IActions actions) : IRequestHandler<UpdatePurchaseByIdCommand, Result<PurchaseDto>>
    {
        public async Task<Result<PurchaseDto>> Handle(UpdatePurchaseByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.Update<Purchase, PurchaseDto>(request.Id, request.Entity, cancellationToken);
        }
    }
}
