using AzureRedisCachingSystem.Models.Cache.Abstract;
using AzureRedisCachingSystem.Repositories.Abstract;
using AzureRedisCachingSystem.Services;

namespace AzureRedisCachingSystem.Repositories;

public class CacheObjectRepository : ICacheObjectRepository
{
    BaseCacheObject ICacheObjectRepository.UserCacheObject { get; set; } = new CacheObject(new RedisCachingService(DbService.GetConnectionString())).SetKey("Users").SetValue(31).SetDurationWithSeconds(300);
}