using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Features.Common;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Roles.Command.DeleteById
{
    public class DeleteRoleByIdHandler(IActions actions) : IRequestHandler<DeleteRoleByIdCommand, Result>
    {
        public async Task<Result> Handle(DeleteRoleByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.DeleteById<Role>(request.Id, cancellationToken);
        }
    }
}
