using System;
using System.Security.Cryptography;
using System.Text;

namespace ID_24_58158_2_LoginSystem
{
    internal static class PasswordHasher
    {
        /// <summary>
        /// Returns a 64-character uppercase SHA-256 hash.
        /// The original password is never stored in the database.
        /// </summary>
        public static string HashPassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            }
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            if (string.IsNullOrEmpty(storedHash))
            {
                return false;
            }

            string candidateHash = HashPassword(password);
            return string.Equals(candidateHash, storedHash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
