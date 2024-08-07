using AzureRedisCachingSystem.Models.Cache;
using AzureRedisCachingSystem.Models.Cache.Abstract;

namespace AzureRedisCachingSystem.Repositories.Abstract;

public interface ICacheObjectRepository
{
    BaseCacheObject BookCacheObject { get; set; }
}
