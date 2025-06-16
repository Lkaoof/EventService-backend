using System.Security.Claims;

namespace EventPlatform.WebApi.Extensions
{
    public static class ClaimPrincipialExtensions
    {
        public static Guid Id(this ClaimsPrincipal user)
        {
            return Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
