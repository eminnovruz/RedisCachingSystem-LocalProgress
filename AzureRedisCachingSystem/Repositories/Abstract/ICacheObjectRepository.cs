using AzureRedisCachingSystem.Models.Cache;
using AzureRedisCachingSystem.Models.Cache.Abstract;

namespace AzureRedisCachingSystem.Repositories.Abstract;

public interface ICacheObjectRepository
{
    BaseCacheObject UserCacheObjectNewVersion { get; set; }
    BaseCacheObject UserCacheObject { get; }
}
