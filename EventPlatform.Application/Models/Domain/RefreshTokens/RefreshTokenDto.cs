using EventPlatform.Application.Common.Mapping;

namespace EventPlatform.Application.Models.Domain.RefreshTokens
{
    public class RefreshTokenDto : IMapWith<RefreshTokenDto>
    {
        public Guid Id { get; set; }
        public string Token { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
    }
}
