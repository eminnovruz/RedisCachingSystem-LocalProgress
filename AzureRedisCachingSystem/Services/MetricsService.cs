using AzureRedisCachingSystem.Cache.Metrics;
using AzureRedisCachingSystem.Configurations;
using AzureRedisCachingSystem.Data;
using AzureRedisCachingSystem.Services.Abstract;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace AzureRedisCachingSystem.Services
{
    public class MetricsService : IMetricsService
    {
        private readonly MongoDbContext context;

        public MetricsService(MongoDbContext context)
        {
            this.context = context;
        }

        public async Task CreateMetrics(CacheMetrics metrics)
            => await context.Metrics.InsertOneAsync(metrics);

        public async Task<bool> HandleCacheHit(string key)
        {
            var filter = Builders<CacheMetrics>.Filter.Eq(m => m.Key, key);
            var update = Builders<CacheMetrics>.Update.Inc(m => m.CacheHits, 1)
                                                      .Set(m => m.LastAccessed, DateTime.UtcNow);

            var result = await context.Metrics.UpdateOneAsync(filter, update);

            return result.ModifiedCount > 0;
        }

        public async Task<bool> HandleCacheMiss()
        {
            return true;
        }

        public async Task<bool> RemoveMetrics()
        {
            var result = await context.Metrics.DeleteManyAsync(FilterDefinition<CacheMetrics>.Empty);

            return result.DeletedCount > 0;
        }
    }
}
