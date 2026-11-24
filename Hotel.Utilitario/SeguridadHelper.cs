using System.Security.Cryptography;
using System.Text;

namespace Hotel.Utilitario
{
    public static class SeguridadHelper
    {
        private const string Salt = "HOTEL_SALT_2026";

        public static string HashPassword(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes($"{Salt}:{password}");
            byte[] hash = SHA256.HashData(bytes);
            return Convert.ToHexString(hash);
        }
    }
}
