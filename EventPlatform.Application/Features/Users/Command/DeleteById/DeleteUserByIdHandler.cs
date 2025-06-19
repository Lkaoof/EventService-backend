using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Users.Command.DeleteById
{
    public class DeleteUserByIdHandler(IActions actions) : IRequestHandler<DeleteUserByIdCommand, Result>
    {
        public async Task<Result> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.DeleteById<User>(request.Id, cancellationToken);
        }
    }
}
