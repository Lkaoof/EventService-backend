using EventPlatform.Domain.Models;

namespace EventPlatform.Application.Interfaces.Application
{
    public interface ITokenService
    {
        Task AddRefreshTokenAsync(RefreshToken refreshToken, CancellationToken ct);
        Task<RefreshToken?> GetActiveTokenAsync(string userRefreshToken, CancellationToken ct);
        Task<RefreshToken?> GetActiveTokenByIdAsync(Guid tokenId, CancellationToken ct);
        IAsyncEnumerable<RefreshToken> GetActiveTokensByUserIdAsync(Guid userId, CancellationToken ct);
        Task RevokeTokenAsync(RefreshToken refreshToken, CancellationToken ct);
    }
}