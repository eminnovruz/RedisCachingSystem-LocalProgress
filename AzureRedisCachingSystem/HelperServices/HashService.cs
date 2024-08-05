using System.Security.Cryptography;
using System.Text;
using RedisCachingSystem.LocalProgress.HelperServices.Abstract;

namespace RedisCachingSystem.LocalProgress.HelperServices
{
    public class HashService : IHashService
    {
        public string HashString(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

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

                return sb.ToString();
            }
        }
    }
}
