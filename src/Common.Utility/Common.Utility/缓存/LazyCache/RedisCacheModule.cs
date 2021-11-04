using System;
using LazyCache.Providers;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Ninject.Modules;

namespace LazyCache
{
    public class LazyCacheModule : NinjectModule
    {
        private readonly Func<IAppCache> implementationFactory;

        public LazyCacheModule()
        {
        }

        public LazyCacheModule(Func<IAppCache> implementationFactory)
        {
            this.implementationFactory = implementationFactory;
        }

        // See also https://github.com/aspnet/Caching/blob/dev/src/Microsoft.Extensions.Caching.Memory/MemoryCacheServiceCollectionExtensions.cs
        public override void Load()
        {
            Bind<IOptions<MemoryCacheOptions>>().ToConstant(Options.Create(new MemoryCacheOptions()));
            Bind<IMemoryCache>().To<MemoryCache>().InSingletonScope();
            Bind<ICacheProvider>().To<MemoryCacheProvider>().InSingletonScope();

            if (implementationFactory == null)
                Bind<IAppCache>().To<CachingService>().InSingletonScope();
            else
                Bind<IAppCache>().ToMethod(context => implementationFactory()).InSingletonScope();
        }
    }

    public class RedisLazyCacheModule : NinjectModule
    {
        private readonly RedisConfiguration configuration;
        private readonly Func<IAppCache> implementationFactory;

        public RedisLazyCacheModule(RedisConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public RedisLazyCacheModule(Func<IAppCache> implementationFactory)
        {
            this.implementationFactory = implementationFactory;
        }

        public override void Load()
        {
            Bind<ICacheProvider>().To<RedisCacheProvider>().InSingletonScope().WithConstructorArgument(typeof(RedisConfiguration), configuration);

            if (implementationFactory == null)
                Bind<IAppCache>().To<RedisCachingService>().InSingletonScope().WithConstructorArgument(typeof(ICacheProvider));
            else
                Bind<IAppCache>().ToMethod(context => implementationFactory()).InSingletonScope();
        }
    }
}
