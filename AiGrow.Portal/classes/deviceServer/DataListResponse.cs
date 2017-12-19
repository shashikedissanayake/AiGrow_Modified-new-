using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AiGrow.Portal 
{
    public class DataListResponse : BaseResponse
    {
        public List<DataResponse> listOfData { get; set; }
    }
}