using AutoMapper;
using AutoMapper.QueryableExtensions;
using EventPlatform.Application.Extentions;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Application.Models.Domain.Users;
using MediatR;

namespace EventPlatform.Application.Features.Users.Query.GetAsPage
{
    public class GetUserAsPageHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetUsersAsPageQuery, Page<UserDto>>
    {
        public async Task<Page<UserDto>> Handle(GetUsersAsPageQuery request, CancellationToken cancellationToken)
        {
            return await context.Users.ProjectTo<UserDto>(mapper.ConfigurationProvider).PaginateAsync(request.Page, cancellationToken);
        }
    }
}
