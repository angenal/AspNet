using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace LazyCache.Providers
{
    /// <summary>
    /// Redis cache provider for LazyCache
    /// </summary>
    public class RedisCacheProvider : ICacheProvider
    {
        /// <summary>
        /// Redis server connection string
        /// </summary>
        private const string DefaultConfiguration = "localhost:6379";

        /// <summary>
        /// Redis database
        /// </summary>
        private const int DataBase = -1;

        /// <summary>
        /// The Redis configuration string
        /// </summary>
        private static string _configuration = DefaultConfiguration;

        /// <summary>
        /// Get the Redis connection multiplexer once
        /// </summary>
        private static readonly Lazy<IConnectionMultiplexer> redis = new Lazy<IConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(_configuration));

        /// <summary>
        /// Redis db instance
        /// </summary>
        public IDatabase Db => redis.Value.GetDatabase(DataBase);

        /// <summary>
        /// Redis cache provider
        /// </summary>
        public RedisCacheProvider()
        {
        }

        /// <summary>
        /// Redis cache provider
        /// </summary>
        /// <param name="configuration"></param>
        public RedisCacheProvider(string configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Redis cache provider
        /// </summary>
        /// <param name="configuration"></param>
        public RedisCacheProvider(RedisConfiguration configuration)
        {
            _configuration = configuration.ToString();
        }

        /// <summary>
        /// Get object from cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            var cacheEntry = InternalGet(key);
            return cacheEntry == null ? default(T) : JsonConvert.DeserializeObject<T>(cacheEntry);
        }

        /// <summary>
        /// Get or create object from cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="func"></param>
        /// <param name="policy"></param>
        /// <returns></returns>
        public object GetOrCreate<T>(string key, Func<ICacheEntry, T> func, MemoryCacheEntryOptions policy)
        {
            var cachedItem = InternalGet(key);
            if (cachedItem != null) return JsonConvert.DeserializeObject<T>(cachedItem);

            var redisCacheEntry = new RedisCacheEntry(policy) { Key = key };
            var typedItem = func.Invoke(redisCacheEntry);

            var cacheEntry = InternalSet(key, typedItem, policy);
            return cacheEntry == null ? default(T) : JsonConvert.DeserializeObject<T>(cacheEntry);
        }

        /// <summary>
        /// Get or create object from cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="func"></param>
        /// <param name="policy"></param>
        /// <returns></returns>
        public async Task<T> GetOrCreateAsync<T>(string key, Func<ICacheEntry, Task<T>> func, MemoryCacheEntryOptions policy)
        {
            var cachedItem = InternalGet(key);
            if (cachedItem != null) return JsonConvert.DeserializeObject<T>(cachedItem);

            var redisCacheEntry = new RedisCacheEntry(policy) { Key = key };
            var typedItem = await func.Invoke(redisCacheEntry);

            var cacheEntry = InternalSet(key, typedItem, policy);
            return cacheEntry == null ? default(T) : JsonConvert.DeserializeObject<T>(cacheEntry);
        }

        /// <summary>
        /// Remove object from cache
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            Db.KeyDelete(key);
        }

        /// <summary>
        /// Set object in cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="item"></param>
        /// <param name="policy"></param>
        public void Set<T>(string key, T item, MemoryCacheEntryOptions policy)
        {
            InternalSet(key, item, policy);
        }

        private string InternalSet(string key, object item, MemoryCacheEntryOptions policy)
        {
            if (item == null) return null;

            TimeSpan? expiry = null;
            if (policy != null)
            {
                expiry = TimeSpan.Zero;
                if (policy.AbsoluteExpiration.HasValue)
                {
                    var now = LazyCache.DefaultConfiguration.UtcTime ? DateTime.UtcNow : DateTime.Now;
                    if (policy.AbsoluteExpiration.Value.DateTime <= now) return null;
                    expiry = policy.AbsoluteExpiration.Value.DateTime.Subtract(now);
                }
                if (policy.AbsoluteExpirationRelativeToNow.HasValue)
                {
                    expiry = policy.AbsoluteExpirationRelativeToNow.Value;
                }
                if (policy.SlidingExpiration.HasValue)
                {
                    expiry = policy.SlidingExpiration.Value;
                }
                if (expiry.Value.TotalSeconds < LazyCache.DefaultConfiguration.DefaultCacheMinSeconds)
                {
                    return null;
                }
            }

            // serialize this entry as json string encoded as a RedisDataEntry
            var serializedObject = JsonConvert.SerializeObject(item);

            Db.StringSet(key, serializedObject, expiry);

            return serializedObject;
        }

        private string InternalGet(string key)
        {
            try
            {
                var content = Db.StringGet(key);
                return content.IsNull || !content.HasValue ? null : content.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
        }
    }
}
