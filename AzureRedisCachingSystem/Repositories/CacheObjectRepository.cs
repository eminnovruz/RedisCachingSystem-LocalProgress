using AzureRedisCachingSystem.Models;
using AzureRedisCachingSystem.Models.Cache;
using AzureRedisCachingSystem.Models.Cache.Abstract;
using AzureRedisCachingSystem.Models.Misc;
using AzureRedisCachingSystem.Repositories.Abstract;
using AzureRedisCachingSystem.Services;
using Microsoft.EntityFrameworkCore;

namespace AzureRedisCachingSystem.Repositories
{
    public class CacheObjectRepository : ICacheObjectRepository
    {
      
        // NEW VERSION

        public BaseCacheObject UserCacheObjectNewVersion { get; set; } = new CacheObject<User>(new RedisCachingService(AppService.GetConnectionString()))
            .SetParams(new User("Emin", "Novruz", "novruzemin693@gmail.com", 16, "0552554459", "1"))
            .SetValue(15)
            .SetDurationWithMonths(1)
            .ActivateTimer();

        public BaseCacheObject BookCacheObjectNewVersion { get; set; } = new CacheObject<Book>(new RedisCachingService(AppService.GetConnectionString()))
            .SetParams(new Book("Ekow", "Al oxuda qedew", "Emin Novruz", 16));
    }
}
