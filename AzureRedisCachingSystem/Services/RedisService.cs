using AzureRedisCachingSystem.Configurations.Redis;
using Microsoft.Extensions.Options;
using RedisCachingSystem.LocalProgress.HelperServices.Abstract;
using RedisCachingSystem.LocalProgress.RedisValue;
using RedisCachingSystem.LocalProgress.Services.Abstract;
using StackExchange.Redis;
using System.Reflection;
using System.Text.Json;

namespace RedisCachingSystem.LocalProgress.Services;

public class RedisService : IRedisService
{
    private readonly IDatabase _database;
    private readonly IHashService _hashService;

    public RedisService(IOptions<RedisConfig> options, IHashService hashService)
    {
        ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(options.Value.ConnectionString);

        _database = redis.GetDatabase();

        _hashService = hashService;
    }

    public async Task<bool> CheckIfExist(string key)
    {
        return await _database.KeyExistsAsync(key);
    }

    public async Task<CustomValue> GetData(string key)
    {
        StackExchange.Redis.RedisValue value = await _database.StringGetAsync(key);

        if (!value.HasValue)
        {
            Console.WriteLine("There is no value realated with given key.");
        }

        string jsonStr = value.ToString();

        CustomValue customValue = new CustomValue()
        {
            Value = JsonSerializer.Deserialize<object>(jsonStr)
        };

        return customValue;
    }

    public async Task<bool> SetData(string key, CustomValue value)
    {
        string valueJson = JsonSerializer.Serialize(value.Value);

        return await _database.StringSetAsync(key, valueJson);
    }

    public async Task<bool> SetExpire(string key, DateTime expireDate)
    {
        return await _database.KeyExpireAsync(key, expireDate);
    }
}
