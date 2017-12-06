using AiGrow.Business;
using AiGrow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace AiGrow.DeviceServer
{
    /// <summary>
    /// Summary description for LocationController
    /// </summary>
    [WebService(Namespace = "http://aigrow.lk")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LocationController : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void AddLocation(string longitude, string latitude, string address, string locationName, string token, string uniqueId)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                if (Encryption.createSHA1(locationName.Trim()) == token)
                {
                    new BL_Location().insert(new ML_Location()
                    {
                        latitude = latitude,
                        location_name = locationName,
                        location_address = address,
                        longitude = longitude,
                        location_unique_id = uniqueId
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

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetToken(string input)
        {
            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(new BaseResponse()
            {
                errorMessage = null,
                success = true,
                message = Encryption.createSHA1(input)
            }));
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void DeleteLocation(string uniqueId)
        {
            BaseResponse response = new BaseResponse();

            new BL_Location().delete(new ML_Location()
            {
                location_unique_id = uniqueId
            });

            response.success = true;
            response.message = UniversalProperties.locationDeletedSuccessfully;
            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(response));
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void UpdateLocation( string uniqueId, string longitude, string latitude, string address, string locationName, string token)
        {
            BaseResponse returnObj = new BaseResponse();

            try
            {
                if (new BL_User().validateToken(token.Trim()) == 1)
                {

                    #region Database Insertion

                    int updateLocation = new AiGrow.Business.BL_Location().update(new ML_Location()
                    {
                        longitude = longitude.IsEmpty() ? null : longitude,
                        latitude = latitude.IsEmpty() ? null : latitude,
                        location_address = address.IsEmpty() ? null : address,
                        location_name = locationName.IsEmpty() ? null : locationName,
                        location_unique_id = uniqueId.IsEmpty() ? null : uniqueId

                    });

                    if (updateLocation != -1)
                    {
                        returnObj.success = true;
                        returnObj.message = UniversalProperties.locationUpdatedSuccesfully;
                    }
                    else
                    {
                        returnObj.success = false;
                        returnObj.errorMessage = UniversalProperties.locationUpdateFailed;
                        returnObj.errorCode = UniversalProperties.EC_RegistrationError;
                    }
                    #endregion
                }
                else
                {
                    returnObj.success = false;
                    returnObj.errorMessage = UniversalProperties.invalidRequest;
                    returnObj.errorCode = UniversalProperties.EC_InvalidRequest;
                }
                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                return;
            }
            catch
            {
                returnObj.success = false;
                returnObj.errorMessage = UniversalProperties.unknownError;
                returnObj.errorCode = UniversalProperties.EC_UnhandledError;
                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                return;
            }
        }
    }
}
