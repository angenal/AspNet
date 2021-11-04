using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace LazyCache
{
    public interface ICacheProvider : IDisposable
    {
        void Set<T>(string key, T item, MemoryCacheEntryOptions policy);
        T Get<T>(string key);
        object GetOrCreate<T>(string key, Func<ICacheEntry, T> func, MemoryCacheEntryOptions policy);
        void Remove(string key);
        Task<T> GetOrCreateAsync<T>(string key, Func<ICacheEntry, Task<T>> func, MemoryCacheEntryOptions policy);
    }
}