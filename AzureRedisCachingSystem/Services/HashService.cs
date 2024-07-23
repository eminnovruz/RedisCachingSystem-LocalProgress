using AzureRedisCachingSystem.Services.Abstract;
using System;
using System.Security.Cryptography;
using System.Text;

namespace AzureRedisCachingSystem.Services
{
    public class HashService : IHashService
    {
        public string HashString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input cannot be null or empty.", nameof(input));
            }

            try
            {
                using var md5 = MD5.Create();
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return ConvertToHexString(hashBytes);
            }
            catch (CryptographicException ex)
            {
                throw new InvalidOperationException("An error occurred while computing the hash.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occurred.", ex);
            }
        }

        private string ConvertToHexString(byte[] bytes)
        {
            try
            {
                var sb = new StringBuilder();
                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while converting bytes to hex string.", ex);
            }
        }
    }
}
