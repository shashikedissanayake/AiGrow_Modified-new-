using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AiGrow
{
    public class LoginResponse : BaseResponse
    {
        public string credentials { get; set; }
        public string token { get; set; }
        public string loginID { get; set; }
    }
}