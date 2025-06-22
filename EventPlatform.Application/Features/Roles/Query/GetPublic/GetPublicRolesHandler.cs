using AutoMapper;
using AutoMapper.QueryableExtensions;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Application.Models.Domain.Roles;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventPlatform.Application.Features.Roles.Query.GetPublic
{
    public class GetPublicRolesHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetPublicRolesQuery, ICollection<RoleDto>>
    {
        public async Task<ICollection<RoleDto>> Handle(GetPublicRolesQuery request, CancellationToken cancellationToken)
        {
            return await context.Roles
                .Where(r => r.isPublic)
                .ProjectTo<RoleDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
