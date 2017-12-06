
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Script.Serialization;

namespace AiGrow
{
    public static class AppFunction
    {
        public static int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }

        public static Double getDoubleFromString(string inpValue)
        {
            if (String.IsNullOrEmpty(inpValue) || inpValue == "")
            {
                return 0.00;
            }
            else
            {
                return Convert.ToDouble(inpValue);
            }
        }

        public static int getIntFromString(string inpValue)
        {
            if (String.IsNullOrEmpty(inpValue) || inpValue == "")
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(inpValue);
            }
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

        public static string doesUserNameExist(string userName)
        {
            RequestHandler post = new RequestHandler();
            post.Url = Constants.CHECK_USERNAME;
            post.PostItems.Add("userName", userName);
            post.Type = RequestHandler.PostTypeEnum.Post;
            string result = post.Post();

            BaseResponse userResponse = new JavaScriptSerializer().Deserialize<BaseResponse>(result);

            // return (userResponse.message.ToString() == true.ToString());
            return new JavaScriptSerializer().Serialize(userResponse);
        }

        public static string doesEmailExist(string email, string token)
        {
            RequestHandler post = new RequestHandler();
            post.Url = Constants.CHECK_EMAIL;
            post.PostItems.Add("email", email);
            post.PostItems.Add("token", token);
            post.Type = RequestHandler.PostTypeEnum.Post;
            string result = post.Post();

            BaseResponse userResponse = new JavaScriptSerializer().Deserialize<BaseResponse>(result);

            return new JavaScriptSerializer().Serialize(userResponse);
        }

    }
}