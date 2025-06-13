using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EventPlatform.Application.Interfaces.Infrastructure;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace EventPlatform.Application.Common.CacheBehavior
{
    public class CacheBehavior<Request, Response>(ICache cache) : IPipelineBehavior<Request, Response>
        where Request : ICacheable 
    {
        public async Task<Response> Handle(Request request, RequestHandlerDelegate<Response> next, CancellationToken cancellationToken)
        {
            if (request.BypassCache()) return await next();

            //Console.WriteLine($"Cached: {request.CacheKey}");
            return await cache.GetOrSetAsync(request.CacheKey, async () => await next(),
                request.ExpirationTime(), cancellationToken);
        }
    }
}
