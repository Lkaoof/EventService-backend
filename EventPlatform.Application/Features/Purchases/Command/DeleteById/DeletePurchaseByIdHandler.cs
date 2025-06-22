using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Purchases.Command.DeleteById
{
    public class DeletePurchaseByIdHandler(IActions actions) : IRequestHandler<DeletePurchaseByIdCommand, Result>
    {
        public async Task<Result> Handle(DeletePurchaseByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.DeleteById<Purchase>(request.Id, cancellationToken);
        }
    }
}
