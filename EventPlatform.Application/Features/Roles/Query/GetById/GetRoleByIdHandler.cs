using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.Roles;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Roles.Query.GetById
{
    public class GetRoleByIdHandler(IActions actions) : IRequestHandler<GetRoleByIdQuery, Result<RoleDto>>
    {
        public async Task<Result<RoleDto>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            return await actions.GetById<Role, RoleDto>(request.Id, cancellationToken);
        }
    }
}
