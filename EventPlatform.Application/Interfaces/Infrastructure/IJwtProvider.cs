﻿using System.Security.Claims;
using EventPlatform.Application.Models.Domain.Users;

namespace EventPlatform.Application.Interfaces.Infrastructure
{
    public interface IJwtProvider
    {
        TimeSpan AccessTokenExpiresMinutes { get; }
        string Audience { get; }
        string CookieName { get; }
        string Issuer { get; }
        TimeSpan RefreshTokenExpiresDays { get; }

        Task<(string accessToken, string refreshToken)> GenerateTokensAsync(UserIdentity user, CancellationToken cancellationToken = default);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        Task<Guid> GetUserIdByRefreshTokenAsync(string token, CancellationToken ct);
        Task RevokeAllUserTokensAsync(Guid userId, CancellationToken cancellationToken = default);
        Task RevokeUserTokenAsync(string token, CancellationToken cancellationToken = default);
        Task<bool> ValidateRefreshToken(string refreshToken, CancellationToken ct);
    }
}