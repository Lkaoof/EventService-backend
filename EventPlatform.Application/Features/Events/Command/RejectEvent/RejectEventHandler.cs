using AutoMapper;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventPlatform.Application.Features.Events.Command.RejectEvent
{
    public class RejectEventHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<RejectEventCommand, Result>
    {
        public async Task<Result> Handle(RejectEventCommand request, CancellationToken cancellationToken)
        {
            var updated = await context.Events
             .Where(e => e.Id == request.EventId)
             .ExecuteUpdateAsync(p => p.SetProperty(e => e.Status, EventStatus.Rejected),
             cancellationToken);

            return updated == 0 ? Result.Failure("Event not updated", Status.BadRequest) : Result.Success();

        }
    }
}
