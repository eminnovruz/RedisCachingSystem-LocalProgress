using AzureRedisCachingSystem.Services.Abstract;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace AzureRedisCachingSystem.Services;

public class RedisCachingService : IMemoryCaching
{
    private IDatabase db;
    private readonly IConnectionMultiplexer _connection;

    public RedisCachingService(string connectionString)
    {
        _connection = ConnectionMultiplexer.Connect(connectionString);
        db = _connection.GetDatabase();
    }

    public async Task<T> GetCacheData<T>(string key)
    {
        var value = await db.StringGetAsync(key);
        if (!string.IsNullOrEmpty(value))
            return JsonConvert.DeserializeObject<T>(value);
        return default;
    }

    public async Task<object> RemoveData(string key)
    {
        var exist = await db.KeyExistsAsync(key);
        if (exist is true)
            return db.KeyDelete(key);
        return false;
    }

    public async Task<bool> SetCacheData<T>(string key, T value, DateTimeOffset expireTime)
    {
        TimeSpan time = expireTime.DateTime.Subtract(DateTime.UtcNow);
        var isSet = await db.StringSetAsync(key, JsonConvert.SerializeObject(value));
        await db.KeyExpireAsync(key, time);
        return isSet;
    }

    public async Task<bool> CheckIfExist(string key)
    {
        return await db.KeyExistsAsync(key);
    }
}
