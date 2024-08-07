using AzureRedisCachingSystem.Models.Cache.Abstract;
using AzureRedisCachingSystem.Services.Abstract;
using Serilog;
using System.Text;

namespace AzureRedisCachingSystem.Models.Cache
{
    public class CacheObject<T> : BaseCacheObject
    {
        public CacheObject(IMemoryCaching cacheService, IHashService hashService)
            : base(cacheService, hashService)
        {
        }

        public CacheObject<T> SetParams(T parameter)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));

            var properties = parameter.GetType().GetProperties();

            foreach (var prop in properties)
            {
                var value = prop.GetValue(parameter);

                if (value is DateTime dateTimeValue)
                {
                    value = dateTimeValue.ToString("M/d/yyyy");
                }

                UniqueKey.Append($"{prop.Name.ToLower()}:{value?.ToString().ToLower()}&*");
            }

            UniqueKey = new StringBuilder(_hashService.HashString(UniqueKey.ToString()));

            Log.Information("Params set to cache object");

            return this;
        }
    }
}
