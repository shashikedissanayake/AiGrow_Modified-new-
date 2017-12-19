using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace AiGrow.Portal.classes
{
    public class GreenhouseServices
    {
        public static LocationListResponse getGreenhouseLocationsById(String user_id, String token)
        {
            RequestHandler post = new RequestHandler();
            post.Url = Constants.GETGREENHOUSELOCATIONS;
            Portal.ApplicationUtilities.writeMsg(post.Url);
            post.PostItems.Add("user_id", user_id);
            post.PostItems.Add("token", token);
            post.Type = RequestHandler.PostTypeEnum.Post;
            string result = post.Post();

            LocationListResponse locations = new JavaScriptSerializer().Deserialize<LocationListResponse>(result);

            return locations;
        }

        public static DataListResponse getGreenhouseDeviceLeastData(string user_id, string token, string greenhouse_id)
        {
            RequestHandler post = new RequestHandler();
            post.Url = Constants.GETGREENHOUSELEASTDEVICEDATA;
            Portal.ApplicationUtilities.writeMsg(post.Url);
            post.PostItems.Add("user_id", user_id);
            post.PostItems.Add("greenhouse_id", greenhouse_id);
            post.PostItems.Add("token", token);
            post.Type = RequestHandler.PostTypeEnum.Post;
            string result = post.Post();

            DataListResponse leastData = new JavaScriptSerializer().Deserialize<DataListResponse>(result);

            return leastData;
        }


    }
}