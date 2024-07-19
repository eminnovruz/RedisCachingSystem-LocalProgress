using AzureRedisCachingSystem.Configurations;
using AzureRedisCachingSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AzureRedisCachingSystem.Data;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseCosmos(
            "https://eminaccount.documents.azure.com:443/",
            "BriCfVzHHeNZYeH8JfsEV7ANZeu59EZIBFoBcbWqo4SGO9v4UyEhK7dhhEzJXVm17Va7GCPEVq44ACDbmL8Pxg==",
            "databasefyp"
            );

        base.OnConfiguring(optionsBuilder);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToContainer("Users");
        modelBuilder.Entity<Book>().ToContainer("Books");

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users {  get; set; }
    public DbSet<Book> Books { get; set; }
}
