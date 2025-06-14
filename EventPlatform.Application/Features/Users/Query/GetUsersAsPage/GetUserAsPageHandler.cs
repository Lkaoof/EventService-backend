using EventPlatform.Application.Extentions;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Users.Query.GetUsersAsPage
{
    public class GetUserAsPageHandler(IDatabaseContext context) : IRequestHandler<GetUsersAsPageQuery, Page<User>>
    {
        public Task<Page<User>> Handle(GetUsersAsPageQuery request, CancellationToken cancellationToken)
        {
            return context.Users.AsQueryable().PaginateAsync(request.Page, cancellationToken);
        }
    }
}
