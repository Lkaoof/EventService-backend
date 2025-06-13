using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlatform.Application.Common.CacheBehavior
{
    public interface ICacheInvalidate
    {
        public string[] CacheKeys { get; }
    }
}
