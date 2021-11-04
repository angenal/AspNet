using ServiceStack.Redis;
using SqlSugar;
using System;
using System.Collections.Generic;

namespace WindowsService.SignalR.Server.ServiceRepository
{
    /// <summary>
    /// Redis 缓存
    ///  Hosts: {password}@{host}:{port}
    /// </summary>
    public class RedisCache : ICacheService
    {
        public RedisCache(IEnumerable<string> readWriteHosts, IEnumerable<string> readOnlyHosts, RedisClientManagerConfig config = null, long initalDb = 0, int poolSizeMultiplier = 500, int poolTimeOutSeconds = -1)
        {
            service = new ServiceStackRedis(readOnlyHosts, readOnlyHosts, config, initalDb, poolSizeMultiplier, poolTimeOutSeconds);
        }

        public void Add<V>(string key, V value)
        {
            service.Set(key, value);
        }

        public void Add<V>(string key, V value, int cacheDurationInSeconds)
        {
            service.Set(key, value, cacheDurationInSeconds);
        }

        public bool ContainsKey<V>(string key)
        {
            return service.ContainsKey(key);
        }

        public V Get<V>(string key)
        {
            return service.Get<V>(key);
        }

        public IEnumerable<string> GetAllKey<V>()
        {
            return service.GetAllKeys();
        }

        public V GetOrCreate<V>(string cacheKey, Func<V> create, int cacheDurationInSeconds = int.MaxValue)
        {
            if (ContainsKey<V>(cacheKey))
            {
                return Get<V>(cacheKey);
            }
            else
            {
                var result = create();
                Add(cacheKey, result, cacheDurationInSeconds);
                return result;
            }
        }

        public void Remove<V>(string key)
        {
            service.Remove(key);
        }

        ServiceStackRedis service = null;
    }

    public class ServiceStackRedis
    {
        private readonly int _expirySeconds = -1;
        private readonly PooledRedisClientManager _redisClientManager;
        private readonly SerializeService _serializeService = new SerializeService();
        public ServiceStackRedis(IEnumerable<string> readWriteHosts, IEnumerable<string> readOnlyHosts, RedisClientManagerConfig config = null, long initalDb = 0, int poolSizeMultiplier = 500, int poolTimeOutSeconds = -1)
        {
            _expirySeconds = poolTimeOutSeconds;
            _redisClientManager = new PooledRedisClientManager(readWriteHosts, readOnlyHosts, config, initalDb, poolSizeMultiplier, poolTimeOutSeconds);
        }

        public bool Set(string key, object value)
        {
            if (key == null) throw new ArgumentNullException("key");

            if (_expirySeconds != -1) return Set(key, value, _expirySeconds);

            var json = _serializeService.SerializeObject(value);
            using (var client = _redisClientManager.GetClient())
            {
                return client.Set(key, json);
            }
        }

        public bool Set(string key, object value, int duration)
        {
            if (key == null) throw new ArgumentNullException("key");

            var json = _serializeService.SerializeObject(value);
            using (var client = _redisClientManager.GetClient())
            {
                return client.Set(key, json, DateTime.Now.AddSeconds(duration));
            }
        }

        public T Get<T>(string key)
        {
            if (key == null) throw new ArgumentNullException("key");

            string data;
            using (var client = _redisClientManager.GetClient())
            {
                data = client.Get<string>(key);
            }
            return data == null ? default(T) : _serializeService.DeserializeObject<T>(data);
        }
        public bool Remove(string key)
        {
            using (var client = _redisClientManager.GetClient())
            {
                return client.Remove(key);
            }
        }

        public bool RemoveAll()
        {
            using (var client = _redisClientManager.GetClient())
            {
                try
                {
                    client.FlushDb();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool ContainsKey(string key)
        {
            using (var client = _redisClientManager.GetClient())
            {
                return client.ContainsKey(key);
            }
        }

        public List<string> GetAllKeys()
        {
            using (var client = _redisClientManager.GetClient())
            {
                return client.SearchKeys("SqlSugarDataCache.*");
            }
        }
    }
}
