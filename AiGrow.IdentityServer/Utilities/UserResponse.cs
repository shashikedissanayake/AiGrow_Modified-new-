using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AiGrow.IdentityServer
{
    public class UserResponse : BaseResponse
    {
        public string title { get; set; }
        public string first_name { get; set; }
        public string gender { get; set; }
        public string last_name { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string telephone { get; set; }
        public string mobile { get; set; }
        public string organization_name { get; set; }
        public string organization_address { get; set; }
        public string username { get; set; }
        public string country { get; set; }
        public string profile_pic_url { get; set; }
    }
}