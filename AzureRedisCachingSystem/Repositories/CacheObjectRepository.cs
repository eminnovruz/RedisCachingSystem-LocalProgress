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
        public BaseCacheObject UserCacheObject { get; set; } 
    }
}
