using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Events.Command.DeleteById
{
    public class DeleteEventByIdHandler(IActions actions) : IRequestHandler<DeleteEventByIdCommand, Result>
    {
        public async Task<Result> Handle(DeleteEventByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.DeleteById<Event>(request.Id, cancellationToken);
        }
    }
}
