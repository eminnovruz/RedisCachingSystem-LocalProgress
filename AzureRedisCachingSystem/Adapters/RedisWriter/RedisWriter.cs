using AzureRedisCachingSystem.Cache.Entries;
using AzureRedisCachingSystem.Cache.Metrics;
using AzureRedisCachingSystem.Cache.Models.Enums;
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
        if(await redisService.CheckKeyExist(entry.Key))
            entry.Key = await HandleKeyConflict(entry.Key);

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

    private async Task<string> HandleKeyConflict(string key)
    {
        string conflictBehaviour = ConfigurationManager.AppSettings["KeyConflictBehaviour"].ToLower();
        int x = 0;

        if (conflictBehaviour == KeyConflictBehaviours.None.ToString().ToLower())
            throw new Exception("Value realated with given key is already exists.. .Try providing another key.");

        else if (conflictBehaviour == KeyConflictBehaviours.MakeChanges.ToString().ToLower())
            while (await redisService.CheckKeyExist(key))
                key += x++.ToString();

        else
            throw new Exception("Unkown Conflict Behaviour error");

        return key;
    }
}
