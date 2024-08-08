using AzureRedisCachingSystem.Cache.Entries;
using AzureRedisCachingSystem.Configurations;
using AzureRedisCachingSystem.HelperServices.Json;
using AzureRedisCachingSystem.Services.Abstract;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace AzureRedisCachingSystem.Services;

public class RedisService : IRedisService
{
    private readonly IDatabase database;

    public RedisService(IOptions<RedisConfig> settings)
    {
        ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(settings.Value.ConnectionString);

        database = redis.GetDatabase();
    }

    public async Task<bool> CheckKeyExist(string key)
        => await database.KeyExistsAsync(key);

    public async Task<RedisValue> ReadFromRedis(string key)
        => await database.StringGetAsync(key);

    public async Task<bool> WriteToRedis(CacheEntry entry)
    {
        RedisKey key = entry.Key;
        RedisValue value = JsonService.SerializeValue(entry.Value);

        bool setResult = await database.StringSetAsync(key, value);

        if (setResult is true)
        {
            TimeSpan expiryTime = entry.Expire - DateTimeOffset.Now;
            await database.KeyExpireAsync(key, expiryTime);
        }

        return setResult;
    }

}
