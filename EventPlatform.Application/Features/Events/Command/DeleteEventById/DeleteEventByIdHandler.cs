using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Features.Common;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Domain.Models;
using MediatR;

namespace EventPlatform.Application.Features.Events.Command.DeleteEventById
{
    public class DeleteEventByIdHandler(IDatabaseContext context, IActions actions) : IRequestHandler<DeleteEventByIdCommand, Result>
    {
        public async Task<Result> Handle(DeleteEventByIdCommand request, CancellationToken cancellationToken)
        {
            return await actions.DeleteById<Event>(request.Id, cancellationToken);
        }
    }
}
