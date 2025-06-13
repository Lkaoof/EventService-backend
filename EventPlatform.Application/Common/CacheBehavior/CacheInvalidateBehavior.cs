using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventPlatform.Application.Interfaces.Infrastructure;
using MediatR;

namespace EventPlatform.Application.Common.CacheBehavior
{
    public class CacheInvalidateBehavior<Request, Response>(ICache cache) : IPipelineBehavior<Request, Response> where Request : ICacheInvalidate
    {
        public async Task<Response> Handle(Request request, RequestHandlerDelegate<Response> next, CancellationToken cancellationToken)
        {
            foreach (var key in request.CacheKeys)
                await cache.RemoveAsync(key, cancellationToken);

            return await next(cancellationToken);
        }
    }
}
