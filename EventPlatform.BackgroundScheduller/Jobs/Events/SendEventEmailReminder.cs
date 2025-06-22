using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Domain.Models;
using Quartz;

namespace EventPlatform.BackgroundScheduller.Jobs.Events
{
    public class SendEventEmailReminder(IEmailSender emailSender, IActions actions) : IJob
    {
        //public static readonly JobKey Key = new JobKey("send-event-reminder", "email");

        public async Task Execute(IJobExecutionContext context)
        {
            var email = context.MergedJobDataMap.GetString("email");
            var eventId = context.MergedJobDataMap.GetString("eventId");
            var eventResult = await actions.GetById<Event>(Guid.Parse(eventId));
            if (eventResult.IsFailure) return;
            var event_ = eventResult.Value;

            await emailSender.SendAsync(email, "Event reminder", $"Hey! Don't miss this event: {event_.Title}. It starts at {event_.StartAt}", default);
        }
    }
}
