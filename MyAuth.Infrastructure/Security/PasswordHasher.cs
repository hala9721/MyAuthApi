using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MyAuth.Infrastructure.Security
{
    internal static class PasswordHasher
    {
        private const int SaltSize = 16 ,keySize = 32 ,iterations = 100_000;
        private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA256;

        public static string Hash(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(SaltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, Algorithm, keySize);
            return $"{Convert.ToHexString(hash)}:{Convert.ToHexString(salt)}";
        }

        public static bool Verify(string password, string hash)
        {
            var parts = hash.Split(":");
            if (parts.Length != 2) return false;
            var salt = Convert.FromHexString(parts[0]);
            var hashToCompare = Convert.FromHexString(parts[1]);
            var inputHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, Algorithm, keySize);
            return CryptographicOperations.FixedTimeEquals(inputHash, hashToCompare);
        }
    }
}
