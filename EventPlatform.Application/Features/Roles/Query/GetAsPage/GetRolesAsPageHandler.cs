using AutoMapper;
using EventPlatform.Application.Extentions;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Application.Pagination;
using EventPlatform.Application.Models.Domain.Roles;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Roles.Query.GetAsPage
{
    public class GetRolesAsPageHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetRolesAsPageQuery, Page<RoleDto>>
    {
        public async Task<Page<RoleDto>> Handle(GetRolesAsPageQuery request, CancellationToken cancellationToken)
        {
            return await context.Roles.AsQueryable().PaginateAsync<Role, RoleDto>(request.Page, mapper, cancellationToken);
        }
    }
}
