using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using RedisCachingSystem.LocalProgress.HelperServices.Abstract;

namespace RedisCachingSystem.LocalProgress.HelperServices
{
    public class HashService : IHashService
    {
        public Task<string> HashString(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return Task.Run(() =>
            {
                using (var sha256 = SHA256.Create())
                {
                    byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                    var sb = new StringBuilder();

                    foreach (var b in bytes)
                    {
                        sb.Append(b.ToString("x2"));
                    }

                    return sb.ToString();
                }
            });
        }
    }
}
