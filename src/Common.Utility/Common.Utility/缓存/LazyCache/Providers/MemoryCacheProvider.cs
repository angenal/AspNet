using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace LazyCache.Providers
{
    public class MemoryCacheProvider : ICacheProvider
    {
        internal readonly IMemoryCache cache;

        public MemoryCacheProvider(IMemoryCache cache)
        {
            this.cache = cache;
        }

        public void Set<T>(string key, T item, MemoryCacheEntryOptions policy)
        {
            cache.Set<T>(key, item, policy);
        }

        public T Get<T>(string key)
        {
            return cache.Get<T>(key);
        }

        public object GetOrCreate<T>(string key, Func<ICacheEntry, T> factory, MemoryCacheEntryOptions policy)
        {
            if (cache.TryGetValue(key, out var obj))
                return (T)obj;
            using (ICacheEntry entry = cache.CreateEntry(key))
            {
                if (policy != null)
                    entry.SetOptions(policy);
                obj = factory(entry);
                entry.SetValue(obj);
            }
            return (T)obj;
        }

        public void Remove(string key)
        {
            cache.Remove(key);
        }

        public async Task<T> GetOrCreateAsync<T>(string key, Func<ICacheEntry, Task<T>> factory, MemoryCacheEntryOptions policy)
        {
            if (cache.TryGetValue(key, out var obj))
                return (T)obj;
            using (ICacheEntry entry = cache.CreateEntry(key))
            {
                if (policy != null)
                    entry.SetOptions(policy);
                obj = await factory(entry);
                entry.SetValue(obj);
            }
            return (T)obj;
        }

        public void Dispose()
        {
            cache?.Dispose();
        }
    }
}