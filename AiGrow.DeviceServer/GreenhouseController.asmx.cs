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
        public void AddGreenhouse(string unique_id, string name, int user_id, int location_id, string token)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                if (Encryption.createSHA1(name.Trim()) == token || new BL_User().validateToken(token) == 1)
                {
                    new BL_Greenhouse().insert(new ML_Greenhouse()
                    {
                        greenhouse_unique_id = unique_id,
                        greenhouse_name = name,
                        owner_user_id = user_id,
                        location_id = location_id,
                    });
                    response.success = true;
                    response.message = UniversalProperties.greenhouseInsertedSuccessfully;
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

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void AddGreenhouseDevice(string unique_id, string name, string device_type, string io_type, int greenhouse_id, string default_unit, string status, string token)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                if (Encryption.createSHA1(unique_id.Trim()) == token || new BL_User().validateToken(token) == 1)
                {
                    new BL_GreenhouseDevice().insert(new ML_GreenhouseDevice()
                    {
                        greenhouse_device_name = name,
                        greenhouse_device_unique_id = unique_id,
                        greenhouse_id = greenhouse_id,
                        device_type = device_type,
                        io_type = io_type,
                        status = status,
                        default_unit = default_unit
                    });
                    response.success = true;
                    response.message = UniversalProperties.greenhouseDeviceInsertedSuccessfully;
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

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void AddBay(string unique_id, int greenhouse_id, string token)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                if (Encryption.createSHA1(unique_id.Trim()) == token || new BL_User().validateToken(token) == 1)
                {
                    new BL_Bay().insert(new ML_Bay()
                    {
                        bay_unique_id = unique_id,
                        greenhouse_id = greenhouse_id
                    });
                    response.success = true;
                    response.message = UniversalProperties.bayInsertedSuccessfully;
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


