using AzureRedisCachingSystem.Adapters.RedisWriter;
using AzureRedisCachingSystem.ApplicationModels;
using AzureRedisCachingSystem.Cache.CustomValues;
using AzureRedisCachingSystem.Cache.Entries;
using AzureRedisCachingSystem.Cache.Settings;
using AzureRedisCachingSystem.Configurations;
using AzureRedisCachingSystem.Services;
using AzureRedisCachingSystem.Services.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//////////////////////////////////////// Dependency Injection

var host = Host.CreateDefaultBuilder(args)
.ConfigureAppConfiguration((context, config) =>
{
    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
})
.ConfigureServices((context, services) =>
{
    services.Configure<RedisConfig>(context.Configuration.GetSection("Redis"));
    services.AddScoped<IRedisService, RedisService>();
})
.Build();

//////////////////////////////////////// Fake data

List<Book> books = new List<Book>()
{
    new Book
    {
        Id = Guid.NewGuid().ToString(),
        Price = 15,
        PublishDate = DateTime.Now,
        Title = "Nagil 101"
    },
    new Book
    {
        Id = Guid.NewGuid().ToString(),
        Price = 15,
        PublishDate = DateTime.Now,
        Title = "Nagil 101"
    },
    new Book
    {
        Id = Guid.NewGuid().ToString(),
        Price = 15,
        PublishDate = DateTime.Now,
        Title = "Nagil 101"
    },
    new Book
    {
        Id = Guid.NewGuid().ToString(),
        Price = 15,
        PublishDate = DateTime.Now,
        Title = "Nagil 101"

    },
};

/////////////////////////////////////// Application

try
{

}
catch (Exception exception)
{
    Console.WriteLine(exception.Message);
}


