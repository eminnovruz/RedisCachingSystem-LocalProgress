using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AzureRedisCachingSystem.Cache.Metrics;

public class CacheMetrics
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)] 
    public string Id { get; set; }

    public string Key { get; set; }
    public int CacheHits { get;  set; }
    public int CacheMisses { get;  set; }
    public DateTime LastAccessed { get;  set; }
}
