using System;
using Microsoft.Extensions.Caching.Memory;

namespace LazyCache
{
    /// <summary>
    /// Default configuration
    /// </summary>
    public static class DefaultConfiguration
    {
        /// <summary>
        /// Default windows not use Utc Time, but linux use Utc Time
        /// </summary>
        public static bool UtcTime = false;
        /// <summary>
        /// Default cache expiry if none is specified
        /// </summary>
        public static int DefaultCacheDurationSeconds = 1200;
        /// <summary>
        /// Default cache expiry min seconds
        /// </summary>
        public static int DefaultCacheMinSeconds = 3;
        /// <summary>
        /// Default Dependency cache expiry
        /// </summary>
        public static MemoryCacheEntryOptions DefaultDependency = new MemoryCacheEntryOptions { SlidingExpiration = TimeSpan.FromDays(1) };

        public static MemoryCacheEntryOptions BuildOptions(int? seconds = null, bool? utcTime = null)
        {
            return new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = (utcTime ?? UtcTime)
                    ? DateTimeOffset.UtcNow.AddSeconds(seconds ?? DefaultCacheDurationSeconds)
                    : DateTimeOffset.Now.AddSeconds(seconds ?? DefaultCacheDurationSeconds)
            };
        }
        public static MemoryCacheEntryOptions BuildOptions(DateTimeOffset time, bool? utcTime = null)
        {
            return new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = (utcTime ?? UtcTime)
                    ? time.ToUniversalTime()
                    : time.ToLocalTime()
            };
        }

        /// <summary>
        /// Set AbsoluteExpiration
        /// </summary>
        /// <param name="options"></param>
        /// <param name="utcTime"></param>
        public static void SetAbsoluteExpiration(this MemoryCacheEntryOptions options, bool? utcTime = null)
        {
            if (options == null || options.AbsoluteExpiration.HasValue)
            {
                return;
            }
            if (options.SlidingExpiration.HasValue)
            {
                options.AbsoluteExpiration = (utcTime ?? UtcTime)
                    ? DateTimeOffset.UtcNow.Add(options.SlidingExpiration.Value)
                    : DateTimeOffset.Now.Add(options.SlidingExpiration.Value);
                options.SlidingExpiration = null;
                return;
            }
            if (options.AbsoluteExpirationRelativeToNow.HasValue)
            {
                options.AbsoluteExpiration = (utcTime ?? UtcTime)
                    ? DateTimeOffset.UtcNow.Add(options.AbsoluteExpirationRelativeToNow.Value)
                    : DateTimeOffset.Now.Add(options.AbsoluteExpirationRelativeToNow.Value);
                options.AbsoluteExpirationRelativeToNow = null;
            }
        }

        public const int DefaultSyncTimeout = 5000;
        public const int DefaultConnectTimeout = 5000;
        public const int DefaultConnectRetry = 3;
        public const int DefaultConfigCheckSeconds = 60;
        public const int DefaultWriteBuffer = 4096;
    }
}
