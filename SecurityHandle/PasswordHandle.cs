using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SecurityHandle
{
        public class PasswordHandle
    {
        private static PasswordHandle _instance;
        public static PasswordHandle GetInstance()
        {
            return _instance ?? (_instance = new PasswordHandle());
        }

        public string GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }

        public string EncryptPassword(string originalPassword, string salt)
        {
            var byteSalt = Encoding.Unicode.GetBytes(salt);
            var bytePassword = Encoding.Unicode.GetBytes(originalPassword);
            using (var hmac = new HMACSHA256(byteSalt))
            {
                return Convert.ToBase64String(hmac.ComputeHash(bytePassword));
            }
        }
    }
}
