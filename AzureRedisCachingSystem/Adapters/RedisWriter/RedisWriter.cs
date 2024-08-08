using AzureRedisCachingSystem.Cache.Entries;
using AzureRedisCachingSystem.Cache.Metrics;
using AzureRedisCachingSystem.Services.Abstract;
using System.Configuration;

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
        await HandleKeyConflict(entry.Key);

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

    private async Task HandleKeyConflict(string key)
    {
        string conflictBehaviour = ConfigurationManager.AppSettings["KeyConflictBehaviour"];
        int x = 0;

        if (conflictBehaviour == "none")
            throw new Exception("Value realated with given key is already exists.. .Try providing another key.");

        else if (conflictBehaviour == "makeChanges")
            while (await redisService.CheckKeyExist(key))
                key += x++.ToString();

        else
            throw new Exception("Unkown Conflict Behaviour error");
    }
}
