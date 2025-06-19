using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.EventMoods.Command.DeleteById
{
    public class DeleteEventMoodByIdHandler(IActions actions) : IRequestHandler<DeleteEventMoodByIdCommand, Result>
    {
        public async Task<Result> Handle(DeleteEventMoodByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.DeleteById<EventMood>(request.Id, cancellationToken);
        }
    }
}
