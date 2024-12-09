using System.Security.Cryptography;

namespace pracaInzynierska_backend.Helpers
{
    public static class PasswordHashHelper
    {
        public static string HashPassword(string password)
        {
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt); 
            }


            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000))
            {
                byte[] hash = pbkdf2.GetBytes(32); 

            
                byte[] hashBytes = new byte[48];
                Buffer.BlockCopy(salt, 0, hashBytes, 0, 16); 
                Buffer.BlockCopy(hash, 0, hashBytes, 16, 32); 

            
                return Convert.ToBase64String(hashBytes);
            }
        }
        public static bool VerifyPassword(string password, string storedHash)
        {

            byte[] hashBytes = Convert.FromBase64String(storedHash);


            byte[] salt = new byte[16];
            Buffer.BlockCopy(hashBytes, 0, salt, 0, 16);


            byte[] storedPasswordHash = new byte[32];
            Buffer.BlockCopy(hashBytes, 16, storedPasswordHash, 0, 32);


            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000))
            {
                byte[] computedHash = pbkdf2.GetBytes(32);
                return CompareByteArrays(storedPasswordHash, computedHash);
            }
        }
        private static bool CompareByteArrays(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
