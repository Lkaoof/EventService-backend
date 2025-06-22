using AutoMapper;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventPlatform.Application.Features.Events.Command.ApproveEvent
{
    public class ApproveEventHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<ApproveEventCommand, Result>
    {
        public async Task<Result> Handle(ApproveEventCommand request, CancellationToken cancellationToken)
        {
            var updated = await context.Events
               .Where(e => e.Id == request.EventId)
               .ExecuteUpdateAsync(p => p.SetProperty(e => e.Status, EventStatus.Approved), cancellationToken);

            return updated == 0 ? Result.Failure("Event not updated", Status.BadRequest) : Result.Success();
        }
    }
}
