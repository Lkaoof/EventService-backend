namespace EventPlatform.Application.Models.Domain.Users
{
    [Flags]
    public enum LoginType
    {
        Email,
        Username,
    }

    public record UserLoginDto(string Login, string Password, LoginType LoginType);
}
