namespace EventPlatform.Application.Common.CacheBehavior
{
    public interface ICacheable
    {
        public string CacheKey { get; }
        public bool BypassCache() => false;
        public TimeSpan ExpirationTime() => TimeSpan.FromMinutes(5);
    }
}
