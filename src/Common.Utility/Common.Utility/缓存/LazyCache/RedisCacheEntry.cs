using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace LazyCache
{
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    internal class RedisCacheEntry : ICacheEntry
    {
        public object Key { get; set; }
        public object Value { get; set; }
        public Type Type { get; set; }
        public DateTimeOffset? AbsoluteExpiration { get; set; }
        public TimeSpan? AbsoluteExpirationRelativeToNow { get; set; }
        public TimeSpan? SlidingExpiration { get; set; }
        public IList<IChangeToken> ExpirationTokens { get; }
        public IList<PostEvictionCallbackRegistration> PostEvictionCallbacks { get; }
        public CacheItemPriority Priority { get; set; }
        public long? Size { get; set; }

        public RedisCacheEntry(MemoryCacheEntryOptions options = null)
        {
            if (options == null) return;
            AbsoluteExpiration = options.AbsoluteExpiration;
            AbsoluteExpirationRelativeToNow = options.AbsoluteExpirationRelativeToNow;
            SlidingExpiration = options.SlidingExpiration;
            ExpirationTokens = options.ExpirationTokens;
            PostEvictionCallbacks = options.PostEvictionCallbacks;
            Priority = options.Priority;
            Size = options.Size;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public override string ToString()
        {
            return Key?.ToString() ?? string.Empty;
        }

        protected virtual void Dispose(bool isDisposing) { }
    }
}
