using AzureRedisCachingSystem.Data;
using AzureRedisCachingSystem.Models.Misc;
using AzureRedisCachingSystem.Repositories.Abstract;
using AzureRedisCachingSystem.Repositories;
using AzureRedisCachingSystem.Services;
using Serilog;
using AzureRedisCachingSystem.Models.Cache;
using AzureRedisCachingSystem.Models;
using AzureRedisCachingSystem.Models.ModelFilters;
using Microsoft.Extensions.Caching.Memory;
using AzureRedisCachingSystem.Services.Abstract;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

}
    