using AzureRedisCachingSystem.Models.Commo;

namespace AzureRedisCachingSystem.Models;

public class Book : BaseEntity 
{
    public Book(string title, string description, string authorFullName, int price)
    {
        Title = title;
        Description = description;
        AuthorFullName = authorFullName;
        Price = price;
    }

    public string Title { get; set; }
    public string Description { get; set; }
    public string AuthorFullName  { get; set; }
    public int Price { get; set; }
}
