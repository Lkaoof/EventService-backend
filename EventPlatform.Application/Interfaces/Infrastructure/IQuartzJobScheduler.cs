namespace EventPlatform.Application.Interfaces.Infrastructure
{
    public interface IQuartzJobScheduler
    {
        Task ScheduleAwait(DateTimeOffset executeAt, Guid userId, Guid eventId, CancellationToken cancellationToken = default);

        //Task StartAsync(CancellationToken cancellationToken);

        Task ScheduleEmailSend(DateTimeOffset executeAt, string email, string subject, string content, CancellationToken cancellationToken);
    }
}