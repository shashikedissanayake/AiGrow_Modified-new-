using System;
using System.Security.Cryptography;
using System.Text; 

namespace AiGrow.IdentityServer
{
    public class Encryption
    {
        public static String createSHA1(String inputString)
        {
            Encoding enc = Encoding.Default;
            byte[] buffer = enc.GetBytes(inputString);
            SHA1CryptoServiceProvider cryptoTransformSha1 = new SHA1CryptoServiceProvider();
            string hash = BitConverter.ToString(cryptoTransformSha1.ComputeHash(buffer)).Replace("-", "");
            return hash;
        }

        public static string createMd5(MD5 md5Hash, String input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}