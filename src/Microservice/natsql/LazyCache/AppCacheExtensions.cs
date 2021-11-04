using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace LazyCache
{
    public static class AppCacheExtensions
    {
        public static void Add<T>(this IAppCache cache, string key, T item)
        {
            cache.Add(key, item, cache.DefaultCachePolicy.BuildOptions());
        }

        public static void Add<T>(this IAppCache cache, string key, T item, DateTimeOffset expires)
        {
            if (expires == DateTimeOffset.MinValue)
                cache.Add(key, item);
            else
                cache.Add(key, item, new MemoryCacheEntryOptions { AbsoluteExpiration = expires });
        }

        public static void Add<T>(this IAppCache cache, string key, T item, TimeSpan slidingExpiration)
        {
            if (slidingExpiration == TimeSpan.Zero)
                cache.Add(key, item);
            else
                cache.Add(key, item, new MemoryCacheEntryOptions { SlidingExpiration = slidingExpiration });
        }

        public static T GetOrAdd<T>(this IAppCache cache, string key, Func<T> addItemFactory)
        {
            return cache.GetOrAdd(key, addItemFactory, cache.DefaultCachePolicy.BuildOptions());
        }

        public static T GetOrAdd<T>(this IAppCache cache, string key, Func<T> addItemFactory, DateTimeOffset expires)
        {
            if (expires == DateTimeOffset.MinValue)
                return cache.GetOrAdd(key, addItemFactory);
            return cache.GetOrAdd(key, addItemFactory, new MemoryCacheEntryOptions { AbsoluteExpiration = expires });
        }

        public static T GetOrAdd<T>(this IAppCache cache, string key, Func<T> addItemFactory, TimeSpan slidingExpiration)
        {
            if (slidingExpiration == TimeSpan.Zero)
                return cache.GetOrAdd(key, addItemFactory);
            return cache.GetOrAdd(key, addItemFactory, new MemoryCacheEntryOptions { SlidingExpiration = slidingExpiration });
        }

        public static T GetOrAdd<T>(this IAppCache cache, string key, Func<T> addItemFactory, MemoryCacheEntryOptions policy)
        {
            return cache.GetOrAdd(key, entry =>
            {
                entry.SetOptions(policy);
                return addItemFactory();
            }, policy);
        }

        public static Task<T> GetOrAddAsync<T>(this IAppCache cache, string key, Func<Task<T>> addItemFactory)
        {
            return cache.GetOrAddAsync(key, addItemFactory, cache.DefaultCachePolicy.BuildOptions());
        }

        public static Task<T> GetOrAddAsync<T>(this IAppCache cache, string key, Func<Task<T>> addItemFactory, DateTimeOffset expires)
        {
            if (expires == DateTimeOffset.MinValue)
                return cache.GetOrAddAsync(key, addItemFactory);
            return cache.GetOrAddAsync(key, addItemFactory, new MemoryCacheEntryOptions { AbsoluteExpiration = expires });
        }

        public static Task<T> GetOrAddAsync<T>(this IAppCache cache, string key, Func<Task<T>> addItemFactory, TimeSpan slidingExpiration)
        {
            if (slidingExpiration == TimeSpan.Zero)
                return cache.GetOrAddAsync(key, addItemFactory);
            return cache.GetOrAddAsync(key, addItemFactory, new MemoryCacheEntryOptions { SlidingExpiration = slidingExpiration });
        }

        public static Task<T> GetOrAddAsync<T>(this IAppCache cache, string key, Func<Task<T>> addItemFactory, MemoryCacheEntryOptions policy)
        {
            return cache.GetOrAddAsync(key, entry =>
            {
                entry.SetOptions(policy);
                return addItemFactory();
            }, policy);
        }
    }
}