using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.Roles;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Roles.Command.UpdateById
{
    public class UpdateRoleByIdHandler(IActions actions) : IRequestHandler<UpdateRoleByIdCommand, Result<RoleDto>>
    {
        public async Task<Result<RoleDto>> Handle(UpdateRoleByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.Update<Role, RoleDto>(request.Id, request.Entity, cancellationToken);
        }
    }
}
