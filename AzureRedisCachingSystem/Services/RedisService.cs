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

    public Task<bool> CheckIfExist(string key)
    {
        throw new NotImplementedException();
    }

    public async Task<CustomValue> GetData(string key)
    {
        StackExchange.Redis.RedisValue value = await _database.StringGetAsync(key);

        if(!value.HasValue)
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
        if (value?.Value == null)
        {
            throw new ArgumentNullException(nameof(value), "Value cannot be null");
        }

        string serializedValue;

        if (value.Value is IDictionary<string, object> dictionary)
        {
            serializedValue = string.Join("&*", dictionary.Select(kv => $"{kv.Key}:{kv.Value}")) + "&*";
        }
        else
        {
            var properties = value.Value.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var propStrings = properties.Select(p => $"{p.Name}:{p.GetValue(value.Value)}");
            serializedValue = string.Join("&*", propStrings) + "&*";
        }

        if (key.Length > 32)
        {
            key = _hashService.HashString(key);
        }

        var setResult = await _database.StringSetAsync(key, serializedValue);

        return setResult;
    }

}
