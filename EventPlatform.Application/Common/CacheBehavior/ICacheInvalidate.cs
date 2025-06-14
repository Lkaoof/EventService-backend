namespace EventPlatform.Application.Common.CacheBehavior
{
    public interface ICacheInvalidate
    {
        public string[] CacheKeys { get; }
    }
}
