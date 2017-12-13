using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using AiGrow.Business;
using AiGrow.Model;
using System.Web.Script.Serialization;
using System.Data;

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
        public void AddGreenhouse(string greenhouse_unique_id, string name, int user_id, int location_id, string token)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                if (Encryption.createSHA1(name.Trim()) == token || new BL_User().validateToken(token) == 1)
                {
                    if (!new BL_Greenhouse().doesGreenhouseExist(greenhouse_unique_id))
                    {
                        new BL_Greenhouse().insert(new ML_Greenhouse()
                        {
                            greenhouse_unique_id = greenhouse_unique_id,
                            greenhouse_name = name,
                            owner_user_id = user_id,
                            location_id = location_id,
                        });
                        response.success = true;
                        response.message = UniversalProperties.greenhouseInsertedSuccessfully;
                    }
                    response.success = false;
                    response.errorCode = UniversalProperties.EC_RegistrationError;
                    response.errorMessage = UniversalProperties.DUPLICATE_GREENHOUSE;
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
        public void AddGreenhouseDevice(string greenhouse_device_unique_id, string name, string device_type, string io_type, int greenhouse_id, string default_unit, string status, string token)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                if (Encryption.createSHA1(greenhouse_device_unique_id.Trim()) == token || new BL_User().validateToken(token) == 1)
                {
                    if (!new BL_GreenhouseDevice().doesDeviceExist(greenhouse_device_unique_id))
                    {
                        new BL_GreenhouseDevice().insert(new ML_GreenhouseDevice()
                        {
                            greenhouse_device_name = name,
                            greenhouse_device_unique_id = greenhouse_device_unique_id,
                            greenhouse_id = greenhouse_id,
                            device_type = device_type,
                            io_type = io_type,
                            status = status,
                            default_unit = default_unit
                        });
                        response.success = true;
                        response.message = UniversalProperties.greenhouseDeviceInsertedSuccessfully;
                    }
                    response.success = false;
                    response.errorCode = UniversalProperties.EC_RegistrationError;
                    response.errorMessage = UniversalProperties.DUPLICATE_GREENHOUSE_DEVICE;
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
        public void AddBay(string bay_unique_id, int greenhouse_id, string token)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                if (Encryption.createSHA1(bay_unique_id.Trim()) == token || new BL_User().validateToken(token) == 1)
                {
                    if (!new BL_Bay().doesBayExist(bay_unique_id))
                    {
                        new BL_Bay().insert(new ML_Bay()
                        {
                            bay_unique_id = bay_unique_id,
                            greenhouse_id = greenhouse_id
                        });
                        response.success = true;
                        response.message = UniversalProperties.bayInsertedSuccessfully;
                    }
                    response.success = false;
                    response.errorCode = UniversalProperties.EC_RegistrationError;
                    response.errorMessage = UniversalProperties.DUPLICATE_BAY;
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
        public void AddBayLine(string bay_line_unique_id, int bay_id, string token)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                if (Encryption.createSHA1(bay_line_unique_id.Trim()) == token || new BL_User().validateToken(token) == 1)
                {
                    if (!new BL_BayLine().doesBayLineExist(bay_line_unique_id))
                    {
                        new BL_BayLine().insert(new ML_BayLine()
                        {
                            bay_line_unique_id = bay_line_unique_id,
                            bay_id = bay_id
                        });
                        response.success = true;
                        response.message = UniversalProperties.bayInsertedSuccessfully;
                    }
                    response.success = false;
                    response.errorCode = UniversalProperties.EC_RegistrationError;
                    response.errorMessage = UniversalProperties.DUPLICATE_BAY_LINE;
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
        public void GetGreenouseLocationsByUserID(string user_id, string token)
        {
            token = token.Trim();

            if (new BL_User().validateToken(token) == 1)
            {
                LocationResponse response = new LocationResponse();
                try
                {
                    DataTable allLocations = new Business.BL_Location().getAllLocations(user_id);

                    List<LocationResponse> locationList = new List<LocationResponse>();

                    foreach (DataRow item in allLocations.Rows)
                    {
                        locationList.Add(new LocationResponse()
                        {
                            location_address = item["location_address"].ToString(),
                            latitude = item["latitude"].ToString(),
                            longitude = item["longitude"].ToString(),
                            location_name = item["location_name"].ToString(),
                            location_unique_id = item["location_unique_id"].ToString(),
                            location_id = item["location_id"].ToString(),
                        });
                    }
                    HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(new LocationListResponse()
                    {
                        success = true,
                        errorMessage = null,
                        listOfLocations = locationList
                    }));
                    return;
                }
                catch 
                {
                    HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(new BaseResponse()
                    {
                        success = false,
                        errorCode = UniversalProperties.EC_UnhandledError,
                        errorMessage = UniversalProperties.unknownError
                    }));
                }
                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(response));

            }
            else
            {
                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(new LocationResponse()
                {
                    success = false,
                    errorMessage = UniversalProperties.invalidRequest,
                    errorCode = UniversalProperties.EC_InvalidRequest,
                }));
            }

        }
    }
}


