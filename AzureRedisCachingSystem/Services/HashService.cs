using AzureRedisCachingSystem.Services.Abstract;
using System;
using System.Security.Cryptography;
using System.Text;

namespace AzureRedisCachingSystem.Services
{
    /// <summary>
    /// Provides hashing services for strings using MD5 algorithm.
    /// </summary>
    public class HashService : IHashService
    {
        /// <summary>
        /// Computes the MD5 hash of the given input string and returns it as a hexadecimal string.
        /// </summary>
        /// <param name="input">The input string to hash.</param>
        /// <returns>The hexadecimal representation of the MD5 hash.</returns>
        /// <exception cref="ArgumentException">Thrown when the input string is null or empty.</exception>
        /// <exception cref="InvalidOperationException">Thrown when an error occurs during hashing.</exception>
        /// <exception cref="ApplicationException">Thrown when an unexpected error occurs.</exception>
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

        /// <summary>
        /// Converts the given byte array to its hexadecimal string representation.
        /// </summary>
        /// <param name="bytes">The byte array to convert.</param>
        /// <returns>The hexadecimal string representation of the byte array.</returns>
        /// <exception cref="ApplicationException">Thrown when an error occurs during conversion.</exception>
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
