using System;
using Microsoft.Extensions.Caching.Memory;

namespace LazyCache
{
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class CacheDefaults
    {
        public virtual bool UtcTime { get; set; } = DefaultConfiguration.UtcTime;
        public virtual int DefaultCacheDurationSeconds { get; set; } = DefaultConfiguration.DefaultCacheDurationSeconds;
        public virtual int DefaultCacheMinSeconds { get; set; } = DefaultConfiguration.DefaultCacheMinSeconds;

        public MemoryCacheEntryOptions BuildOptions()
        {
            return DefaultConfiguration.BuildOptions(DefaultCacheDurationSeconds, UtcTime);
        }
        public MemoryCacheEntryOptions BuildOptions(int seconds)
        {
            return DefaultConfiguration.BuildOptions(seconds, UtcTime);
        }
        public MemoryCacheEntryOptions BuildOptions(DateTimeOffset time)
        {
            return DefaultConfiguration.BuildOptions(time, UtcTime);
        }
    }
}