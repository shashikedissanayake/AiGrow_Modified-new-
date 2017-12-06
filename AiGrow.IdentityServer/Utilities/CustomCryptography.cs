using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AiGrow.IdentityServer
{
    public class CustomCryptography
    {
        public string[] encryptPassword(string password, string salt = null)
        {
            salt = salt.IsEmpty() ? getSalt(20) : salt;
            SHA256Managed mySHA256 = new SHA256Managed();
            string hex = BitConverter.ToString(mySHA256.ComputeHash(Encoding.Unicode.GetBytes(password + salt))).Replace("-", "");
            return new string[] { hex, salt };

        }

        private string getSalt(int length)
        {
            char[] AvailableCharacters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', '_' };
            char[] identifier = new char[length];
            byte[] randomData = new byte[length];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomData);
            }

            for (int idx = 0; idx < identifier.Length; idx++)
            {
                int pos = randomData[idx] % AvailableCharacters.Length;
                identifier[idx] = AvailableCharacters[pos];
            }

            return new string(identifier);
        }
    }
}