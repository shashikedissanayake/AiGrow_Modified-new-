using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using AiGrow.Business;
using AiGrow.Model;
using System.Web.Script.Serialization;

namespace AiGrow.DeviceServer
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://aigrow.lk/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GreenhouseController : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void AddGreenhouse(string uniqueId, string name, int user_id, int location_id, string token)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                if (Encryption.createSHA1(name.Trim()) == token)
                {
                    new BL_Greenhouse().insert(new ML_Greenhouse()
                    {
                        greenhouse_unique_id = uniqueId,
                        greenhouse_name = name,
                        owner_user_id = user_id,
                        location_id = location_id,
                    });
                    response.success = true;
                    //response.errorCode = UniversalProperties.EC_InvalidRequest;
                    response.message = UniversalProperties.locationInsertedSuccessfully;
                }
                else
                {
                    response.success = false;
                    response.errorCode = UniversalProperties.EC_InvalidRequest;
                    response.errorMessage = UniversalProperties.invalidRequest;
                }
            }
            catch 
            {
                response.success = false;
                response.errorCode = UniversalProperties.EC_UnhandledError;
                response.errorMessage = UniversalProperties.unknownError;
            }
            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(response));
        }
    }
}
