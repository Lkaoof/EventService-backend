using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Quartz;

namespace EventPlatform.BackgroundScheduller.Jobs.Events
{
    public class ChangeEventStatus(IDatabaseContext db) : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var eventId = context.MergedJobDataMap.GetString("eventId");
            var status = context.MergedJobDataMap.GetString("status");

            await db.Events
                .Where(e => e.Id == Guid.Parse(eventId))
                .ExecuteUpdateAsync(p => p
                    .SetProperty(e => e.Status, Enum.Parse<EventStatus>(status))
                );
        }
    }
}
