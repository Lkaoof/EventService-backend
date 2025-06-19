using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Models.Domain.Roles;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Roles.Command.Create
{
    public class CreateRoleHandler(IActions actions) : IRequestHandler<CreateRoleCommand, Result<RoleDto>>
    {
        public async Task<Result<RoleDto>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            return await actions.Create<Role, RoleDto>(request, cancellationToken);
        }
    }
}
