using System.Collections.Concurrent;
using System.Reflection;

namespace EventPlatform.Application.Features.Common
{
    public class DbSetStorage
    {
        public static ConcurrentDictionary<Type, PropertyInfo?> DbSets { get; } = new();
    }
}
