using EventPlatform.Application.Interfaces.Infrastructure;
using MediatR;

namespace EventPlatform.Application.Common.CacheBehavior
{
    public class CacheBehavior<Request, Response>(ICache cache) : IPipelineBehavior<Request, Response>
        where Request : ICacheable
    {
        public async Task<Response> Handle(Request request, RequestHandlerDelegate<Response> next, CancellationToken cancellationToken)
        {
            if (request.BypassCache()) return await next();

            return await cache.GetOrSetAsync(request.CacheKey, async () => await next(),
                request.ExpirationTime(), cancellationToken);
        }
    }
}
