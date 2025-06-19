using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.BackgroundScheduller.Jobs;
using EventPlatform.BackgroundScheduller.Jobs.Events;
using Microsoft.Extensions.Logging;
using Quartz;

namespace EventPlatform.BackgroundScheduller
{
    public class QuartzJobScheduler(ISchedulerFactory schedulerFactory, ILogger<QuartzJobScheduler> logger) : IQuartzJobScheduler
    {
        private readonly ISchedulerFactory _schedulerFactory = schedulerFactory;
        //private readonly ILogger<QuartzJobScheduler> _logger = logger;
        //private IScheduler? _scheduler;

        //public async Task StartAsync(CancellationToken cancellationToken)
        //{
        //    _scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
        //    await _scheduler.Start(cancellationToken);
        //}

        //public async Task ScheduleJobAsync<TJob>(TimeSpan timeOffset, string userId, CancellationToken cancellationToken) where TJob : IJob
        //{
        //    _logger.LogInformation("Scheduling job {JobName} for user {UserId} with message", typeof(TJob).Name, userId);

        //    var jobDetail = JobBuilder.Create<TJob>()
        //        .WithIdentity($"{typeof(TJob).Name}-{userId}")
        //        .UsingJobData("userId", userId)
        //        .Build();

        //    var scheduler = await _schedulerFactory.GetScheduler();
        //    var trigger = TriggerBuilder.Create()
        //        .StartAt(DateTimeOffset.Now.Add(timeOffset))
        //        .Build();

        //    await scheduler.ScheduleJob(jobDetail, trigger, cancellationToken);
        //}

        public async Task ScheduleEventEmailReminder(DateTimeOffset executeAt, string email, Guid eventId, CancellationToken cancellationToken)
        {
            var jobDetail = JobBuilder.Create<SendEventEmailReminder>()
              .WithIdentity($"email-reminder:{email}:event:{eventId}")
              .UsingJobData("email", email)
              .UsingJobData("eventId", eventId)
              .Build();

            var scheduler = await _schedulerFactory.GetScheduler();
            var trigger = TriggerBuilder.Create()
                .StartAt(executeAt)
                .Build();

            await scheduler.ScheduleJob(jobDetail, trigger, cancellationToken);
        }

        public async Task ScheduleEmailSend(DateTimeOffset executeAt, string email, string subject, string content, CancellationToken cancellationToken)
        {
            var jobDetail = JobBuilder.Create<SendEmail>()
              .WithIdentity(SendEmail.Key)
              .UsingJobData("email", email)
              .UsingJobData("subject", subject)
              .UsingJobData("content", content)
              .Build();

            var scheduler = await _schedulerFactory.GetScheduler();
            var trigger = TriggerBuilder.Create()
                .StartAt(executeAt)
                .Build();

            await scheduler.ScheduleJob(jobDetail, trigger, cancellationToken);
        }

        public async Task ScheduleAwait(DateTimeOffset executeAt, Guid userId, Guid eventId, CancellationToken cancellationToken = default)
        {
            var jobDetail = JobBuilder.Create<AwaitSendEmail>()
              .WithIdentity(AwaitSendEmail.Key)
              .UsingJobData("userId", userId.ToString())
              .UsingJobData("eventId", eventId.ToString())
              .Build();

            var scheduler = await _schedulerFactory.GetScheduler();
            var trigger = TriggerBuilder.Create()
                .StartAt(executeAt)
                .Build();

            await scheduler.ScheduleJob(jobDetail, trigger, cancellationToken);
        }

        public async Task DeleteJob(string key, string group)
        {
            var scheduler = await _schedulerFactory.GetScheduler();
            await scheduler.DeleteJob(new JobKey(key, group));
        }
    }
}
