using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.UI.WebControls;

namespace AiGrow.IdentityServer
{
    public static class ApplicationUtilities
    {
        public static int ToInt(this string value)
        {
            return Convert.ToInt32(value);
        }
        public static bool IsEmpty(this string str)
        {
            return str == null ? string.IsNullOrEmpty(str) : string.IsNullOrEmpty(str.Trim());
        }

        public static string ReadSetting(string key)
        {
            string result = "";
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                result = appSettings[key] ?? "Not Found";
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
            return result;
        }
        public static System.Drawing.Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                // Convert byte[] to Image
                ms.Write(imageBytes, 0, imageBytes.Length);
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                return image;
            }
        }
        public static bool IsNotEmpty(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }
        public static bool IsValidEmail(string email)
        {
            System.Text.RegularExpressions.Match m = System.Text.RegularExpressions.Regex.Match(email, @"^[a-zA-Z0-9.!#$%&'*+=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            return (email.Trim().IsNotEmpty() && m.Success);
        }
    }
}