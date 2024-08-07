using System.Security.Cryptography;
using System.Text;

namespace AzureRedisCachingSystem.HelperServices.Hash;

public static class HashService
{
    public static void HashString(ref string input)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

            var truncatedBytes = new byte[16];
            Array.Copy(bytes, truncatedBytes, 16);

            var sb = new StringBuilder();
            foreach (var b in truncatedBytes)
            {
                sb.Append(b.ToString("x2"));
            }

            input = sb.ToString();
        }
    }
}
