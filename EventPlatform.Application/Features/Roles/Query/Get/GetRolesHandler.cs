using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.Roles;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Roles.Query.Get
{
    public class GetRolesHandler(IActions actions) : IRequestHandler<GetRolesQuery, ICollection<RoleDto>>
    {
        public async Task<ICollection<RoleDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetAll<Role, RoleDto>(cancellationToken);
        }
    }
}
