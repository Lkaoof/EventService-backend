using System.Security.Claims;
using EventPlatform.Domain.Models;

namespace EventPlatform.JwtProvider
{
    public interface IJwtProvider
    {
        TimeSpan AccessTokenExpiresMinutes { get; }
        string Audience { get; }
        string CookieName { get; }
        string Issuer { get; }
        TimeSpan RefreshTokenExpiresDays { get; }

        (string accessToken, string refreshToken) GenerateTokensAsync(User user, CancellationToken cancellationToken = default);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}