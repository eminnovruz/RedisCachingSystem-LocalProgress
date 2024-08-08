using AzureRedisCachingSystem.Cache.Entries;
using AzureRedisCachingSystem.Cache.Metrics;
using AzureRedisCachingSystem.Services.Abstract;

namespace AzureRedisCachingSystem.Adapters.RedisWriter;

public class RedisWriter
{
    private readonly IRedisService redisService;
    private readonly IMetricsService metricsService;

    public RedisWriter(IRedisService redisService, IMetricsService metricsService)
    {
        this.redisService = redisService;
        this.metricsService = metricsService;
    }

    public async Task<bool> WriteToCache(CacheEntry entry)
    {
        bool writeResult = await redisService.WriteToRedis(entry);

        if(writeResult)
        {
            CacheMetrics metrics = new CacheMetrics()
            {
                Key = entry.Key,
                CacheHits = 1,
                CacheMisses = 0,
                LastAccessed = DateTime.UtcNow,
            };

            await metricsService.CraeteMetrics(metrics);
        }

        return writeResult;
    }
}
