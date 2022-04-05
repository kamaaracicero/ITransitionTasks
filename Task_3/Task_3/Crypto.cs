using System;
using System.Security.Cryptography;
using System.Text;

namespace Task_3
{
    internal static class Crypto
    {
        public static string GenerateKey()
        {
            var rng = RandomNumberGenerator.Create();
            byte[] bytes = new byte[16];
            rng.GetBytes(bytes);

            return BitConverter.ToString(bytes).Replace("-", string.Empty);
        }

        public static string GenerateHMAC(string key, string message)
        {
            var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));

            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }
    }
}
