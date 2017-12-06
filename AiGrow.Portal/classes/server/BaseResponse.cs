using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AiGrow
{
    public class BaseResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public string errorMessage { get; set; }
        public int errorCode { get; set; }
    }
}
