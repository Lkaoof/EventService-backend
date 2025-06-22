using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Interfaces.Infrastructure
{
    public interface IJobScheduler
    {
        Task ScheduleChangeEventStatus(DateTimeOffset executeAt, EventStatus status, Guid eventId, CancellationToken cancellationToken);

        //Task ScheduleAwait(DateTimeOffset executeAt, Guid userId, Guid eventId, CancellationToken cancellationToken = default);

        //Task StartAsync(CancellationToken cancellationToken);
        //Task ScheduleEmailSend(DateTimeOffset executeAt, string email, string subject, string content, CancellationToken cancellationToken);

        Task ScheduleEventEmailReminder(DateTimeOffset executeAt, string email, Guid eventId, CancellationToken cancellationToken);
    }
}