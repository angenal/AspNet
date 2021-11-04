using LazyCache.Providers;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ninject;

namespace LazyCache
{
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class Memory2RedisCacheService : IAppCache, IDisposable
    {
        /// <summary>
        /// Memory instance
        /// </summary>
        public IMemoryCache Memory { get; }
        /// <summary>
        /// Redis db instance
        /// </summary>
        public IDatabase Redis { get; private set; }

        public ICacheProvider CacheProvider { get; }
        public CacheDefaults DefaultCachePolicy { get; }

        public IAppCache MemoryCache { get; }
        public IAppCache RedisCache { get; private set; }
        public IKernel RedisKernel { get; }

        private readonly Thread threadMemory;
        private readonly ConcurrentQueue<RedisCacheEntry> queueMemory;

        private readonly Thread threadRedis;
        private readonly Dictionary<long, ConcurrentQueue<RedisCacheEntry>> queueRedis;
        private long _timeStamp;
        private long _timeStampSeed;

        public Memory2RedisCacheService(IMemoryCache memory, IAppCache memoryCache, IKernel redisKernel)
        {
            Memory = memory;
            MemoryCache = memoryCache;
            CacheProvider = MemoryCache.CacheProvider;
            DefaultCachePolicy = MemoryCache.DefaultCachePolicy;
            RedisKernel = redisKernel;
            RedisCache = RedisKernel.Get<IAppCache>();
            Redis = ((RedisCacheProvider)RedisCache.CacheProvider).Db;

            queueMemory = new ConcurrentQueue<RedisCacheEntry>();
            threadMemory = new Thread(InternalMemoryStore) { IsBackground = true };
            threadMemory.Start();

            queueRedis = new Dictionary<long, ConcurrentQueue<RedisCacheEntry>>();
            _timeStamp = _timeStampSeed = DateTimeOffset.Now.ToUnixTimeSeconds();
            queueRedis.Add(_timeStamp, new ConcurrentQueue<RedisCacheEntry>());
            threadRedis = new Thread(InternalRedisStore) { IsBackground = true };
            threadRedis.Start();
        }

        private void ResetRedis()
        {
            lock (Redis)
            {
                RedisCache = RedisKernel.Get<IAppCache>();
                Redis = ((RedisCacheProvider)RedisCache.CacheProvider).Db;
            }
        }

        public void Add<T>(string key, T item, MemoryCacheEntryOptions policy)
        {
            policy.SetAbsoluteExpiration(DefaultCachePolicy.UtcTime);
            MemoryCache.Add(key, item, policy);
            queueRedis[_timeStamp].Enqueue(new RedisCacheEntry(policy) { Key = key, Value = item });
        }

        public virtual void Set<T>(string key, T item, DateTime dependencyTimestamp)
        {
            var policy = new MemoryCacheEntryOptions { AbsoluteExpiration = new DateTimeOffset(dependencyTimestamp), Size = 0 };
            MemoryCache.Set(key, item, dependencyTimestamp);
            queueRedis[_timeStamp].Enqueue(new RedisCacheEntry(policy) { Key = key, Value = item });
        }

        public T Get<T>(string key)
        {
            var item = MemoryCache.Get<T>(key);
            if (item != null) return item;

            item = RedisCache.Get<T>(key);
            if (item != null) queueMemory.Enqueue(new RedisCacheEntry() { Key = key, Value = item });
            return item;
        }

        public virtual T Get<T>(string key, DateTime dependencyTimestamp)
        {
            return Get<T>(key + dependencyTimestamp.Ticks);
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var item = await MemoryCache.GetAsync<T>(key);
            if (item != null) return item;

            item = await RedisCache.GetAsync<T>(key);
            if (item != null) queueMemory.Enqueue(new RedisCacheEntry() { Key = key, Value = item });
            return item;
        }

        public async Task<T> GetAsync<T>(string key, DateTime dependencyTimestamp)
        {
            return await GetAsync<T>(key + dependencyTimestamp.Ticks);
        }

        public T GetOrAdd<T>(string key, Func<ICacheEntry, T> addItemFactory, MemoryCacheEntryOptions policy)
        {
            var item = Get<T>(key);
            if (item != null) return item;

            policy.SetAbsoluteExpiration(DefaultCachePolicy.UtcTime);
            item = MemoryCache.GetOrAdd(key, addItemFactory, policy);
            queueRedis[_timeStamp].Enqueue(new RedisCacheEntry(policy) { Key = key, Value = item });
            return item;
        }

        public async Task<T> GetOrAddAsync<T>(string key, Func<ICacheEntry, Task<T>> addItemFactory, MemoryCacheEntryOptions policy)
        {
            var item = await GetAsync<T>(key);
            if (item != null) return item;

            policy.SetAbsoluteExpiration(DefaultCachePolicy.UtcTime);
            item = await MemoryCache.GetOrAddAsync(key, addItemFactory, policy);
            queueRedis[_timeStamp].Enqueue(new RedisCacheEntry(policy) { Key = key, Value = item });
            return item;
        }

        public void Remove(string key)
        {
            MemoryCache.Remove(key);
            RedisCache.Remove(key);
        }

        private void InternalMemoryStore()
        {
            while (true)
            {
                Thread.Sleep(100);
                var i = 10000;
                while (0 < i-- && queueMemory.TryDequeue(out var s))
                {
                    try
                    {
                        if (s.AbsoluteExpiration.HasValue)
                        {
                            var policy = DefaultCachePolicy.BuildOptions(s.AbsoluteExpiration.Value);
                            MemoryCache.Add(s.Key.ToString(), s.Value, policy);
                        }
                        else
                        {
                            var relativeToNow = Redis.KeyTimeToLive(s.Key.ToString()); // get redis ttl seconds
                            if (!relativeToNow.HasValue || relativeToNow.Value.TotalSeconds < DefaultCachePolicy.DefaultCacheMinSeconds)
                                continue; // ignored zero value, check min value
                            MemoryCache.Add(s.Key.ToString(), s.Value, relativeToNow.Value);
                        }
                    }
                    catch (Exception)
                    {
                        queueMemory.Enqueue(s);
                    }
                }
            }
        }

        private void InternalRedisStore()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    lock (queueRedis) queueRedis.Add(_timeStamp + 1, new ConcurrentQueue<RedisCacheEntry>());
                    Thread.Sleep(1000);
                    Interlocked.Increment(ref _timeStamp);
                }
            }, TaskCreationOptions.LongRunning);
            while (true)
            {
                Thread.Sleep(1000);
                try
                {
                    while (_timeStampSeed < _timeStamp)
                    {
                        var items = queueRedis[_timeStampSeed];
                        while (items.TryDequeue(out var s) && s.AbsoluteExpiration.HasValue)
                        {
                            try
                            {
                                if (s.Size.HasValue && s.Size == 0)
                                {
                                    RedisCache.Set(s.Key.ToString(), s.Value, s.AbsoluteExpiration.Value.DateTime);
                                }
                                else
                                {
                                    var policy = DefaultCachePolicy.BuildOptions(s.AbsoluteExpiration.Value);
                                    RedisCache.Add(s.Key.ToString(), s.Value, policy);
                                }
                            }
                            catch (Exception)
                            {
                                items.Enqueue(s);
                                ResetRedis();
                            }
                        }
                        lock (queueRedis) queueRedis.Remove(_timeStampSeed);
                        _timeStampSeed++;
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }

        public void Dispose()
        {
            threadRedis?.Join();
            threadMemory?.Abort(null);
        }
    }
}
