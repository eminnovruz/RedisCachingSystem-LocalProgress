using System.Reflection;

namespace AzureRedisCachingSystem.HelperServices.UniqueKey;

public static class UniqueKeyService
{
    public static void GenerateUniqueKeyViaParams(string key,object parameter)
    {
        PropertyInfo[] properties = parameter.GetType().GetProperties();

        foreach (var prop in properties)
        {
            object value = prop.GetValue(parameter);

            key += $"{prop.Name.ToLower()}:{value.ToString().Replace(" ", "")}";
        }
    }
}
