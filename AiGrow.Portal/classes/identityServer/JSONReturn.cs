using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace AiGrow
{
    public class JSONReturn
    {
        public string property { get; set; }
        public string value { get; set; }
        public string errorText { get; set; }
      /*  public static JSONReturn[] DeserializedJson(string responseJson)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            var t = jsSerializer.Deserialize<JSONReturn[]>(responseJson); ;
            return jsSerializer.Deserialize<JSONReturn[]>(responseJson);
        }

        public JSONReturn()
        {

        }
       * */
    }


  

}