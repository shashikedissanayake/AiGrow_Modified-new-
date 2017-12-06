using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Model
{
    public class ML_Login
    {
        public string login_mode { get; set; }
        public string login_token { get; set; }
        public DateTime logged_in_timestamp { get; set; }
        public DateTime logged_out_timestamp { get; set; }
        public int id_login { get; set; }
        public int id_user { get; set; }
    }
}
