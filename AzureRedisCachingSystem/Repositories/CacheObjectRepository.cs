
using AzureRedisCachingSystem.Models.Cache.Abstract;
using AzureRedisCachingSystem.Repositories.Abstract;

namespace AzureRedisCachingSystem.Repositories
{
    public class CacheObjectRepository : ICacheObjectRepository
    {
        public BaseCacheObject UserCacheObject { get; set; }
        public BaseCacheObject BookCacheObject { get; set; }
    }
}
