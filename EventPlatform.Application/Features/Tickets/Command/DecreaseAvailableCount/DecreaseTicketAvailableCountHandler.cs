using AutoMapper;
using EventPlatform.Application.Common.ResultWrapper;
using EventPlatform.Application.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventPlatform.Application.Features.Tickets.Command.DecreaseAvailableCount
{
    public class DecreaseTicketAvailableCountHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<DecreaseTicketAvailableCountCommand, Result>
    {
        public async Task<Result> Handle(DecreaseTicketAvailableCountCommand request, CancellationToken cancellationToken)
        {
            var updatesCount = await context.Tickets
                .Where(t => t.Id == request.Id)
                .ExecuteUpdateAsync(p => p.SetProperty(t => t.AvailableCount, t => t.AvailableCount - 1), cancellationToken);

            return updatesCount == 0 ? Result.Failure() : Result.Success();
        }
    }
}
