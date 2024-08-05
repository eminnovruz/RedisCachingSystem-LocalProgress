using AzureRedisCachingSystem.Configurations.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RedisCachingSystem.LocalProgress.Cache;
using RedisCachingSystem.LocalProgress.FilterModels;
using RedisCachingSystem.LocalProgress.HelperServices;
using RedisCachingSystem.LocalProgress.HelperServices.Abstract;
using RedisCachingSystem.LocalProgress.ObjectReciever;
using RedisCachingSystem.LocalProgress.RedisValue;
using RedisCachingSystem.LocalProgress.Services;
using RedisCachingSystem.LocalProgress.Services.Abstract;

namespace RedisCachingSystem.LocalProgress;

class Program
{
    static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    services.Configure<RedisConfig>(context.Configuration.GetSection("Redis"));

                    services.AddScoped<IRedisService, RedisService>();
                    services.AddScoped<IHashService, HashService>();
                })
                .Build();

        //bool result = await new CacheObject(host.Services.GetRequiredService<IHashService>(), host.Services.GetRequiredService<IRedisService>())
        //    .SetParams(
        //        value: new ContractFilterModel()
        //        {
        //            StartDate = new DateTime(2000, 9, 9),
        //            Status = "onProgress",
        //            ContractId = "nocontractid",
        //            ContractValue = 4,
        //            Counterparty = "contractParty",
        //            EndDate = new DateTime(2000, 9, 9),
        //            Notes = "no notes",
        //            Title = "Main Contract"
        //        }
        //    )
        //    .SetValue(
        //        value: new CustomValue()
        //        {
        //            Value = new List<string>()
        //            {
        //                "vorzakone",
        //                "vorzakone",
        //                "vorzakone",
        //                "vorzakone",
        //                "vorzakone",
        //                "vorzakone",
        //                "vorzakone",
        //                "vorzakone",
        //                "vorzakone",
        //            }
        //        }
        //    )
        //    .BuildCache();

        CacheObjectReciever reciever = new CacheObjectReciever(host.Services.GetRequiredService<IHashService>(), host.Services.GetRequiredService<IRedisService>());

        CustomValue custom = await reciever.GetValueViaParams(new ContractFilterModel()
        {
            StartDate = new DateTime(2000, 9, 9),
            Status = "onProgress",
            ContractId = "nocontractid",
            ContractValue = 4,
            Counterparty = "contractParty",
            EndDate = new DateTime(2000, 9, 9),
            Notes = "no notes",
            Title = "Main Contract"
        });

        Console.WriteLine(custom.Value.ToString());
    }
}
