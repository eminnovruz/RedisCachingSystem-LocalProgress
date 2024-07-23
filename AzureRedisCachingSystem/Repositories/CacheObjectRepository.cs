using AzureRedisCachingSystem.Models.Cache.Abstract;
using AzureRedisCachingSystem.Models.Misc;
using AzureRedisCachingSystem.Repositories.Abstract;
using AzureRedisCachingSystem.Services;

namespace AzureRedisCachingSystem.Repositories
{
    public class CacheObjectRepository : ICacheObjectRepository
    {
        private readonly BaseCacheObject _userCacheObject;

        public CacheObjectRepository()
        {
            var redisService = new RedisCachingService(DbService.GetConnectionString());

            _userCacheObject = new CacheObject(redisService)
                .SetKey("Book")
                .SetValue(new KValue<string>("Elxan Elatli"))
                .SetDurationWithSeconds(300);
        }

        public BaseCacheObject UserCacheObject
        {
            get => _userCacheObject;
            set => throw new InvalidOperationException("UserCacheObject cannot be set directly.");
        }
    }
}
