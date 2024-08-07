using AzureRedisCachingSystem.Cache.Entries;
using Newtonsoft.Json;

namespace AzureRedisCachingSystem.HelperServices.Json;

public static class JsonService
{
    public static string SerializeEntry(CacheEntry entry)
    {
        string entryJsonString = JsonConvert.SerializeObject(entry);

        if (string.IsNullOrEmpty(entryJsonString))
            throw new Exception("Error occured while attemp on serializing object");

        return entryJsonString;
    }
}
