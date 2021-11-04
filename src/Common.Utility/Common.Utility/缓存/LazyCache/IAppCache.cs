using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace LazyCache
{
    public interface IAppCache
    {
        ICacheProvider CacheProvider { get; }

        /// <summary>
        ///     Define the number of seconds to cache objects for by default
        /// </summary>
        CacheDefaults DefaultCachePolicy { get; }

        void Add<T>(string key, T item, MemoryCacheEntryOptions policy);

        void Set<T>(string key, T item, DateTime dependencyTimestamp);

        T Get<T>(string key);

        T Get<T>(string key, DateTime dependencyTimestamp);

        T GetOrAdd<T>(string key, Func<ICacheEntry, T> addItemFactory, MemoryCacheEntryOptions policy);

        Task<T> GetAsync<T>(string key);

        Task<T> GetAsync<T>(string key, DateTime dependencyTimestamp);

        Task<T> GetOrAddAsync<T>(string key, Func<ICacheEntry, Task<T>> addItemFactory, MemoryCacheEntryOptions policy);

        void Remove(string key);
    }
}