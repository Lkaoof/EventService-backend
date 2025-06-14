using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Features.Common;
using EventPlatform.Application.Interfaces.Infrastructure;
using MediatR;

namespace EventPlatform.Application.Features.Users.Command.DeleteUserById
{
    public class DeleteUserByIdHandler(IDatabaseContext context, IActions actions) : IRequestHandler<DeleteUserByIdCommand, Result>
    {
        public async Task<Result> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.DeleteById(context.Users, request.Id, cancellationToken);
        }
    }
}
