namespace EventPlatform.Application.Interfaces.Infrastructure
{
    public interface IEmailSender
    {
        Task SenAsync(IEnumerable<string> emails, string subject, string content, CancellationToken ct);
        Task SendAsync(string email, string subject, string content, CancellationToken ct);
    }
}