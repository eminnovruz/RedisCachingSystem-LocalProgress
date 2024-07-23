using AzureRedisCachingSystem.Models.Cache.Abstract;
using AzureRedisCachingSystem.Models.Misc;
using AzureRedisCachingSystem.Repositories.Abstract;
using AzureRedisCachingSystem.Services;

namespace AzureRedisCachingSystem.Repositories;

public class CacheObjectRepository : ICacheObjectRepository
{
    BaseCacheObject ICacheObjectRepository.UserCacheObject { get; set; } = new CacheObject(new RedisCachingService(DbService.GetConnectionString())).SetKey("Books").SetValue(new KValue<string>("25")).SetDurationWithSeconds(300);
}