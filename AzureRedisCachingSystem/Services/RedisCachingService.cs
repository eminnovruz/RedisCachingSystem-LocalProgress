using AzureRedisCachingSystem.Configurations;
using AzureRedisCachingSystem.Services.Abstract;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace AzureRedisCachingSystem.Services
{
    
    public class RedisCachingService : IMemoryCaching
    {
        private readonly IDatabase database;

        public RedisCachingService(string connectionStr)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(connectionStr);
            database = redis.GetDatabase();
        }

        public async Task<T> GetCacheData<T>(string key)
        {
            var value = await database.StringGetAsync(key);
            if (!string.IsNullOrEmpty(value))
                return JsonConvert.DeserializeObject<T>(value);
            return default;
        }
        public async Task<object> RemoveData(string key)
        {
            var exists = await database.KeyExistsAsync(key);
            if (exists)
                return await database.KeyDeleteAsync(key);
            return false;
        }
       
        public async Task<bool> SetCacheData<T>(string key, T value, DateTimeOffset expireTime)
        {
            TimeSpan timeToLive = expireTime.DateTime.Subtract(DateTime.UtcNow);
            var isSet = await database.StringSetAsync(key, JsonConvert.SerializeObject(value));
            await database.KeyExpireAsync(key, timeToLive);
            return isSet;
        }
   
        public async Task<bool> CheckIfExist(string key)
        {
            return await database.KeyExistsAsync(key);
        }
    }
}
