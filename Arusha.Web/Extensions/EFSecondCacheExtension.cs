using CacheManager.Core;
using EFCoreSecondLevelCacheInterceptor;
using Microsoft.Extensions.DependencyInjection;
using System;
using Newtonsoft.Json;

namespace Arusha.Web.Extensions
{
    public static class EFSecondCacheExtension
    {
        public static void AddSecondCache(this IServiceCollection services)
        {
            services.AddEFSecondLevelCache(options =>
            {
                options.UseCacheManagerCoreProvider().DisableLogging(false);
                options.CacheAllQueries(CacheExpirationMode.Absolute, TimeSpan.FromMinutes(30));
            });

            // Add an in-memory cache service provider
            services.AddSingleton(typeof(ICacheManager<>), typeof(BaseCacheManager<>));
            services.AddSingleton(typeof(ICacheManagerConfiguration),
                new ConfigurationBuilder()
                        .WithJsonSerializer()
                        .WithMicrosoftMemoryCacheHandle(instanceName: "MemoryCache1")
                        .Build());
        }
    }
}
