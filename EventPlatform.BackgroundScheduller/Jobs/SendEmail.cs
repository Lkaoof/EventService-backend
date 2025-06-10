using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventPlatform.EmailProvider;
using Quartz;

namespace EventPlatform.BackgroundScheduller.Jobs
{
    public class SendEmail(IEmailSender email) : IJob
    {
        public static readonly JobKey Key = new JobKey("send-email", "email");
        private readonly IEmailSender _email = email;

        public async Task Execute(IJobExecutionContext context)
        {
            var email = context.MergedJobDataMap.GetString("email");
            var subject = context.MergedJobDataMap.GetString("subject");
            var content = context.MergedJobDataMap.GetString("content");
            await _email.SendAsync(email, subject, content, default);
            //Console.WriteLine($"Task executed! User id {email} {subject} {content}");
        }
    }
}
