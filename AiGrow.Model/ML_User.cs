using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Model
{
    public class ML_User
    {
        public string title { get; set; }
        public string gender { get; set; }
        public string telephone { get; set; }
        public string mobile { get; set; }
        public string username { get; set; }
        public string country { get; set; }
        public DateTime created_date { get; set; }
        public DateTime last_modified { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public string organization_name { get; set; }
        public string profile_picture_url { get; set; }
        public int id_user { get; set; }
        public int role_id { get; set; }
        public bool deleted { get; set; }
    }
}
