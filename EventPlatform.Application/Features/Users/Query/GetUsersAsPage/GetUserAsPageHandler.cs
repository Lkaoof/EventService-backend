using AutoMapper;
using EventPlatform.Application.Extentions;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Application.Models.Domain.Users;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Users.Query.GetUsersAsPage
{
    public class GetUserAsPageHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetUsersAsPageQuery, Page<UserDto>>
    {
        public Task<Page<UserDto>> Handle(GetUsersAsPageQuery request, CancellationToken cancellationToken)
        {
            return context.Users.AsQueryable().PaginateAsync<User, UserDto>(request.Page, mapper, cancellationToken);
        }
    }
}
