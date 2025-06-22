using AutoMapper;
using EventPlatform.Application.Extentions;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Application.Models.Domain.Purchases;
using EventPlatform.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventPlatform.Application.Features.Purchases.Query.GetAsPage
{
    public class GetPurchasesAsPageHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetPurchasesAsPageQuery, Page<PurchaseDto>>
    {
        public async Task<Page<PurchaseDto>> Handle(GetPurchasesAsPageQuery request, CancellationToken cancellationToken)
        {
            return await context.Purchases
                .Where(p => p.CustomerId == request.UserId)
                .AsNoTracking()
                .PaginateAsync<Purchase, PurchaseDto>
                (request.Page, mapper, cancellationToken);
        }
    }
}
