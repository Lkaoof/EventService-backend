using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventPlatform.Application.Interfaces.Application;
using EventPlatform.Application.Interfaces.Infrastructure;
using EventPlatform.Domain.Models;
using Quartz;

namespace EventPlatform.BackgroundScheduller.Jobs.Events
{
    public class SendEventEmailReminder(IEmailSender emailSender, IActions actions, CancellationToken ct) : IJob
    {
        public static readonly JobKey Key = new JobKey("send-event-reminder", "email");

        public async Task Execute(IJobExecutionContext context)
        {
            var email = context.MergedJobDataMap.GetString("email");
            var eventId = context.MergedJobDataMap.GetGuid("eventId");
            var eventResult = await actions.GetById<Event>(eventId, ct);
            if (eventResult.IsFailure) return;
            var event_ = eventResult.Value;
            
            await emailSender.SendAsync(email, "Event reminder", $"Hey! Don't miss this event: {event_.Title}. It starts at {event_.StartAt}", ct);
        }
    }
}
