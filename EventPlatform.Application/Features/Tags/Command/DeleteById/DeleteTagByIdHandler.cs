using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Tags.Command.DeleteById
{
    public class DeleteTagByIdHandler(IActions actions) : IRequestHandler<DeleteTagByIdCommand, Result>
    {
        public async Task<Result> Handle(DeleteTagByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.DeleteById<Tag>(request.Id, cancellationToken);
        }
    }
}
