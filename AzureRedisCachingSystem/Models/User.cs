using AzureRedisCachingSystem.Models.Common;

namespace AzureRedisCachingSystem.Models;

public class User : BaseEntity
{
    public User(string name, string surname, string email, int age, string phoneNumber, string facultyId)
    {
        Name = name;
        Surname = surname;
        Email = email;
        Age = age;
        PhoneNumber = phoneNumber;
        FacultyId = facultyId;
    }

    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; } 
    public int Age { get; set; }
    public string PhoneNumber { get; set; }
    public string FacultyId { get; set; }
}

