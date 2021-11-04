using Microsoft.Extensions.Caching.Memory;
using Ninject;

namespace LazyCache
{
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    /// <summary>
    /// Memory + Redis Caches
    /// (packages.config : LazyCache,Ninject,StackExchange.Redis)
    /// </summary>
    public sealed class Memory2RedisCache
    {
        public static IKernel MemoryKernel;
        public static IKernel RedisKernel;

        public static IAppCache Memory;
        public static IAppCache Redis;
        public static IAppCache Default;

        /// <summary>
        /// Init Memory + Redis Caches
        /// </summary>
        /// <param name="configuration">Redis Connection Configuration</param>
        /// <param name="defaultExpirationSeconds">1 hour expiration time</param>
        public static void Init(RedisConfiguration configuration, int defaultExpirationSeconds = 3600)
        {
            MemoryKernel = new StandardKernel(new LazyCacheModule());
            RedisKernel = new StandardKernel(new RedisLazyCacheModule(configuration));
            Memory = MemoryKernel.Get<IAppCache>();
            Redis = RedisKernel.Get<IAppCache>();
            Memory.DefaultCachePolicy.DefaultCacheDurationSeconds = defaultExpirationSeconds;
            Redis.DefaultCachePolicy.DefaultCacheDurationSeconds = defaultExpirationSeconds;
            DefaultConfiguration.DefaultCacheDurationSeconds = defaultExpirationSeconds;
            Default = new Memory2RedisCacheService(MemoryKernel.Get<IMemoryCache>(), Memory, RedisKernel);
        }

        /// <summary>
        /// New IAppCache of instance = Memory2RedisCacheService, not Memory2RedisCache.Default
        /// </summary>
        /// <param name="configuration">RedisConfiguration</param>
        /// <returns>Memory2RedisCacheService</returns>
        public static IAppCache New(RedisConfiguration configuration)
        {
            var kernel = new StandardKernel(new LazyCacheModule());
            var redisKernel = new StandardKernel(new RedisLazyCacheModule(configuration));
            return new Memory2RedisCacheService(kernel.Get<IMemoryCache>(), kernel.Get<IAppCache>(), redisKernel);
        }

        public static void Dispose()
        {
            ((RedisCachingService)((Memory2RedisCacheService)Default)?.MemoryCache)?.Dispose();
        }
    }
}
