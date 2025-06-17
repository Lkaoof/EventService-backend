using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Features.Common;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.EventTypes.Command.DeleteById
{
    public class DeleteEventTypeByIdHandler(IActions actions) : IRequestHandler<DeleteEventTypeByIdCommand, Result>
    {
        public async Task<Result> Handle(DeleteEventTypeByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.DeleteById<EventType>(request.Id, cancellationToken);
        }
    }
}
