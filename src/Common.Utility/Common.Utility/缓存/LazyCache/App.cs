using System;

namespace LazyCache
{
    /// <summary>
    /// App缓存管理
    /// </summary>
    public static class App
    {
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="key"></param>
        /// <param name="cache"></param>
        /// <returns></returns>
        public static TResult GetCache<TResult>(string key, CacheMethod cache = CacheMethod.Memory)
        {
            return cache == CacheMethod.Memory ? Memory2RedisCache.Memory.Get<TResult>(key)
                : cache == CacheMethod.Redis ? Memory2RedisCache.Redis.Get<TResult>(key)
                : Memory2RedisCache.Default.Get<TResult>(key);
        }

        public static TResult GetRedisCache<TResult>(string key) => GetCache<TResult>(key, CacheMethod.Redis);

        /// <summary>
        /// 获取缓存+依赖指定DateTime
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="key"></param>
        /// <param name="dependencyTimestamp"></param>
        /// <param name="cache"></param>
        /// <returns></returns>
        public static TResult GetCache<TResult>(string key, DateTime dependencyTimestamp, CacheMethod cache = CacheMethod.Memory)
        {
            return cache == CacheMethod.Memory ? Memory2RedisCache.Memory.Get<TResult>(key, dependencyTimestamp)
                : cache == CacheMethod.Redis ? Memory2RedisCache.Redis.Get<TResult>(key, dependencyTimestamp)
                : Memory2RedisCache.Default.Get<TResult>(key, dependencyTimestamp);
        }

        public static TResult GetRedisCache<TResult>(string key, DateTime dependencyTimestamp) => GetCache<TResult>(key, dependencyTimestamp, CacheMethod.Redis);

        /// <summary>
        /// 获取缓存或不存在时添加
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="key"></param>
        /// <param name="valueFactory"></param>
        /// <param name="expireTime"></param>
        /// <param name="cache"></param>
        /// <returns></returns>
        public static TResult GetCacheOrAdd<TResult>(string key, Func<string, TResult> valueFactory, DateTime? expireTime = null, CacheMethod cache = CacheMethod.Memory)
        {
            var expires = expireTime?.Subtract(DateTime.Now) ?? TimeSpan.Zero;
            if (cache == CacheMethod.Memory)
                return Memory2RedisCache.Memory.GetOrAdd<TResult>(key, () => valueFactory(key), expires);
            if (cache == CacheMethod.Redis)
                return Memory2RedisCache.Redis.GetOrAdd<TResult>(key, () => valueFactory(key), expires);
            return Memory2RedisCache.Default.GetOrAdd<TResult>(key, () => valueFactory(key), expires);
        }

        public static TResult GetRedisCacheOrAdd<TResult>(string key, Func<string, TResult> valueFactory, DateTime? expireTime = null) => GetCacheOrAdd<TResult>(key, valueFactory, expireTime, CacheMethod.Redis);

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expirationSeconds"></param>
        /// <param name="cache"></param>
        public static void SetCache<TResult>(string key, TResult value, int expirationSeconds = 600, CacheMethod cache = CacheMethod.Memory)
        {
            var expires = TimeSpan.FromSeconds(expirationSeconds);
            if (cache == CacheMethod.Memory) Memory2RedisCache.Memory.Add(key, value, expires);
            else if (cache == CacheMethod.Redis) Memory2RedisCache.Redis.Add(key, value, expires);
            else Memory2RedisCache.Default.Add(key, value, expires);
        }
        public static void SetRedisCache<TResult>(string key, TResult value, int expirationSeconds = 600) => SetCache<TResult>(key, value, expirationSeconds, CacheMethod.Redis);
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireTime"></param>
        /// <param name="cache"></param>
        public static void SetCache<TResult>(string key, TResult value, DateTime? expireTime, CacheMethod cache = CacheMethod.Memory)
        {
            var expires = expireTime?.Subtract(DateTime.Now) ?? TimeSpan.Zero;
            if (cache == CacheMethod.Memory) Memory2RedisCache.Memory.Add(key, value, expires);
            else if (cache == CacheMethod.Redis) Memory2RedisCache.Redis.Add(key, value, expires);
            else Memory2RedisCache.Default.Add(key, value, expires);
        }
        public static void SetRedisCache<TResult>(string key, TResult value, DateTime? expireTime) => SetCache<TResult>(key, value, expireTime, CacheMethod.Redis);
        /// <summary>
        /// 设置缓存+依赖指定DateTime
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="dependencyTimestamp"></param>
        /// <param name="cache"></param>
        public static void SetCacheDependency<TResult>(string key, TResult value, DateTime dependencyTimestamp, CacheMethod cache = CacheMethod.Memory)
        {
            if (cache == CacheMethod.Memory) Memory2RedisCache.Memory.Set(key, value, dependencyTimestamp);
            else if (cache == CacheMethod.Redis) Memory2RedisCache.Redis.Set(key, value, dependencyTimestamp);
            else Memory2RedisCache.Default.Set(key, value, dependencyTimestamp);
        }
        public static void SetRedisCacheDependency<TResult>(string key, TResult value, DateTime dependencyTimestamp) => SetCacheDependency<TResult>(key, value, dependencyTimestamp, CacheMethod.Redis);
        /// <summary>
        /// 设置缓存当天
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cache"></param>
        public static void SetCacheToday<TResult>(string key, TResult value, CacheMethod cache = CacheMethod.Memory)
        {
            var expireTime = CacheDay(DateTime.Now);
            if (expireTime.AddSeconds(-10) < DateTime.Now) expireTime = DateTime.Now.AddSeconds(10);
            SetCache<TResult>(key, value, expireTime, cache);
        }
        public static void SetRedisCacheToday<TResult>(string key, TResult value) => SetCacheToday<TResult>(key, value, CacheMethod.Redis);

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key"></param>
        public static void RemoveCache(string key, CacheMethod cache = CacheMethod.Memory)
        {
            if (cache == CacheMethod.Memory) Memory2RedisCache.Memory.Remove(key);
            else if (cache == CacheMethod.Redis) Memory2RedisCache.Redis.Remove(key);
            else Memory2RedisCache.Default.Remove(key);
        }
        public static void RemoveRedisCache(string key) => RemoveCache(key, CacheMethod.Redis);

        /// <summary>
        /// 缓存当天 TimeSpan TotalSeconds
        /// </summary>
        /// <returns></returns>
        public static int CacheToday() => CacheToday(DateTime.Now);
        /// <summary>
        /// 缓存当天 TimeSpan TotalSeconds
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static int CacheToday(DateTime t) => (int)(new DateTime(t.Year, t.Month, t.Day).AddDays(1) - t).TotalSeconds;
        /// <summary>
        /// 缓存当天 DateTime
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static DateTime CacheDay(DateTime t) => new DateTime(t.Year, t.Month, t.Day, 23, 59, 59);
    }

    /// <summary>
    /// 缓存方法
    /// </summary>
    public enum CacheMethod
    {
        /// <summary>
        /// 内存 缓存
        /// </summary>
        Memory = 0,
        /// <summary>
        /// Redis 缓存
        /// </summary>
        Redis = 1,
        /// <summary>
        /// 内存+Redis
        /// </summary>
        TwoLevel
    }
}
