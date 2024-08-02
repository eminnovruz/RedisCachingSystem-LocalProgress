using AzureRedisCachingSystem.Configurations.Redis;
using Microsoft.Extensions.Options;
using RedisCachingSystem.LocalProgress.RedisValue;
using RedisCachingSystem.LocalProgress.Services.Abstract;
using StackExchange.Redis;

namespace RedisCachingSystem.LocalProgress.Services;

public class RedisService : IRedisService
{
    private readonly IDatabase _database;

    public RedisService(IOptions<RedisConfig> options)
    {
        ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(options.Value.ConnectionString);

        _database = redis.GetDatabase();
    }

    public Task<bool> CheckIfExist(string key)
    {
        throw new NotImplementedException();
    }

    public async Task<StackExchange.Redis.RedisValue> GetData(string key)
    {
        StackExchange.Redis.RedisValue value = await _database.StringGetAsync(key);

        if(!value.HasValue)
        {
            throw new ApplicationException("Error occured!");
        }

        return value;
    }
    
    public async Task<bool> SetData(string key, CustomValue value)
    {
        bool setResult = await _database.StringSetAsync(key, value.ToString());

        return setResult;
    }
}
