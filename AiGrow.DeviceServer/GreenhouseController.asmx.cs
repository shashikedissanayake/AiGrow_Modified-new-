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
        #region addComponents

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void AddGreenhouse(string greenhouse_unique_id, string name, int user_id, int location_id, string pic_url, string token)
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
                            pic_url = pic_url
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
        public void AddBayDevice(string bay_device_unique_id, string name, string device_type, string io_type, int bay_id, string default_unit, string status, string token)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                if (Encryption.createSHA1(bay_device_unique_id.Trim()) == token || new BL_User().validateToken(token) == 1)
                {
                    if (!new BL_BayDevice().doesDeviceExist(bay_device_unique_id))
                    {
                        new BL_BayDevice().insert(new ML_BayDevice()
                        {
                            bay_device_name = name,
                            bay_device_unique_id = bay_device_unique_id,
                            bay_id = bay_id,
                            device_type = device_type,
                            io_type = io_type,
                            status = status,
                            default_unit = default_unit
                        });
                        response.success = true;
                        response.message = UniversalProperties.bayDeviceInsertedSuccessfully;
                    }
                    response.success = false;
                    response.errorCode = UniversalProperties.EC_RegistrationError;
                    response.errorMessage = UniversalProperties.DUPLICATE_BAY_DEVICE;
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
                        response.message = UniversalProperties.bayLineInsertedSuccessfully;
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
        public void AddBayLineDevice(string bayLine_device_unique_id, string name, string device_type, string io_type, int bay_line_id, string default_unit, string status, string token)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                if (Encryption.createSHA1(bayLine_device_unique_id.Trim()) == token || new BL_User().validateToken(token) == 1)
                {
                    if (!new BL_BayLineDevice().doesDeviceExist(bayLine_device_unique_id))
                    {
                        new BL_BayLineDevice().insert(new ML_BayLineDevice()
                        {
                            bay_line_device_name = name,
                            bay_line_device_unique_id = bayLine_device_unique_id,
                            bay_line_id = bay_line_id,
                            device_type = device_type,
                            io_type = io_type,
                            status = status,
                            default_unit = default_unit
                        });
                        response.success = true;
                        response.message = UniversalProperties.bayLineDeviceInsertedSuccessfully;
                    }
                    response.success = false;
                    response.errorCode = UniversalProperties.EC_RegistrationError;
                    response.errorMessage = UniversalProperties.DUPLICATE_BAY_LINE_DEVICE;
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
        public void AddBayRack(string bay_rack_unique_id, int bay_id, string token)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                if (Encryption.createSHA1(bay_rack_unique_id.Trim()) == token || new BL_User().validateToken(token) == 1)
                {
                    if (!new BL_BayRack().doesBayRackExist(bay_rack_unique_id))
                    {
                        new BL_BayRack().insert(new ML_BayRack()
                        {
                            rack_unique_id = bay_rack_unique_id,
                            bay_id = bay_id
                        });
                        response.success = true;
                        response.message = UniversalProperties.bayRackInsertedSuccessfully;
                    }
                    response.success = false;
                    response.errorCode = UniversalProperties.EC_RegistrationError;
                    response.errorMessage = UniversalProperties.DUPLICATE_BAY_RACK;
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
        public void AddBayRackDevice(string bayRack_device_unique_id, string name, string device_type, string io_type, int bay_rack_id, string default_unit, string status, string token)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                if (Encryption.createSHA1(bayRack_device_unique_id.Trim()) == token || new BL_User().validateToken(token) == 1)
                {
                    if (!new BL_BayRackDevice().doesDeviceExist(bayRack_device_unique_id))
                    {
                        new BL_BayRackDevice().insert(new ML_BayRackDevice()
                        {
                            rack_device_name = name,
                            device_unique_id = bayRack_device_unique_id,
                            rack_id = bay_rack_id,
                            device_type = device_type,
                            io_type = io_type,
                            status = status,
                            default_unit = default_unit
                        });
                        response.success = true;
                        response.message = UniversalProperties.bayRackDeviceInsertedSuccessfully;
                    }
                    response.success = false;
                    response.errorCode = UniversalProperties.EC_RegistrationError;
                    response.errorMessage = UniversalProperties.DUPLICATE_BAY_RACK_DEVICE;
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
        public void AddBayRackLevel(string bay_rack_level_unique_id, int bay_rack_id, string token)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                if (Encryption.createSHA1(bay_rack_level_unique_id.Trim()) == token || new BL_User().validateToken(token) == 1)
                {
                    if (!new BL_BayRackLevel().doesBayRackLevelExist(bay_rack_level_unique_id))
                    {
                        new BL_BayRackLevel().insert(new ML_BayRackLevel()
                        {
                            level_unique_id = bay_rack_level_unique_id,
                            rack_id = bay_rack_id
                        });
                        response.success = true;
                        response.message = UniversalProperties.bayRackLevelInsertedSuccessfully;
                    }
                    response.success = false;
                    response.errorCode = UniversalProperties.EC_RegistrationError;
                    response.errorMessage = UniversalProperties.DUPLICATE_BAY_RACK_LEVEL;
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
        public void AddBayRackLevelDevice(string bayRackLevel_device_unique_id, string name, string device_type, string io_type, int bay_rack_level_id, string default_unit, string status, string token)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                if (Encryption.createSHA1(bayRackLevel_device_unique_id.Trim()) == token || new BL_User().validateToken(token) == 1)
                {
                    if (!new BL_BayRackLevelDevice().doesDeviceExist(bayRackLevel_device_unique_id))
                    {
                        new BL_BayRackLevelDevice().insert(new ML_BayRackLevelDevice()
                        {
                            level_device_name = name,
                            level_device_unique_id = bayRackLevel_device_unique_id,
                            level_id = bay_rack_level_id,
                            device_type = device_type,
                            io_type = io_type,
                            status = status,
                            default_unit = default_unit
                        });
                        response.success = true;
                        response.message = UniversalProperties.bayRackLevelDeviceInsertedSuccessfully;
                    }
                    response.success = false;
                    response.errorCode = UniversalProperties.EC_RegistrationError;
                    response.errorMessage = UniversalProperties.DUPLICATE_BAY_RACK_LEVEL_DEVICE;
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
        public void AddBayRackLevelLine(string bay_rack_level_line_unique_id, int bay_rack_level_id, string token)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                if (Encryption.createSHA1(bay_rack_level_line_unique_id.Trim()) == token || new BL_User().validateToken(token) == 1)
                {
                    if (!new BL_BayRackLevelLine().doesBayRackLevelLineExist(bay_rack_level_line_unique_id))
                    {
                        new BL_BayRackLevelLine().insert(new ML_BayRackLevelLine()
                        {
                            level_line_unique_id = bay_rack_level_line_unique_id,
                            level_id = bay_rack_level_id
                        });
                        response.success = true;
                        response.message = UniversalProperties.bayRackLevelLineInsertedSuccessfully;
                    }
                    response.success = false;
                    response.errorCode = UniversalProperties.EC_RegistrationError;
                    response.errorMessage = UniversalProperties.DUPLICATE_BAY_RACK_LEVEL_LINE;
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
        public void AddBayRackLevelLineDevice(string bayRackLevelLine_device_unique_id, string name, string device_type, string io_type, int bay_rack_level_line_id, string default_unit, string status, string token)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                if (Encryption.createSHA1(bayRackLevelLine_device_unique_id.Trim()) == token || new BL_User().validateToken(token) == 1)
                {
                    if (!new BL_BayRackLevelLineDevice().doesDeviceExist(bayRackLevelLine_device_unique_id))
                    {
                        new BL_BayRackLevelLineDevice().insert(new ML_BayRackLevelLineDevice()
                        {
                            level_line_device_name = name,
                            level_line_device_unique_id = bayRackLevelLine_device_unique_id,
                            level_line_id = bay_rack_level_line_id,
                            device_type = device_type,
                            io_type = io_type,
                            status = status,
                            default_unit = default_unit
                        });
                        response.success = true;
                        response.message = UniversalProperties.bayRackLevelLineDeviceInsertedSuccessfully;
                    }
                    response.success = false;
                    response.errorCode = UniversalProperties.EC_RegistrationError;
                    response.errorMessage = UniversalProperties.DUPLICATE_BAY_RACK_LEVEL_LINE_DEVICE;
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

        #endregion
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetAllGreenhouseLocations(string user_id, string token)
        {
            token = token.Trim();

            if ((new BL_User().validateTokenByUserID(user_id, token) == 1) && (new BL_User().checkForAdmin(user_id)==1))
            {
                LocationResponse response = new LocationResponse();
                try
                {
                    DataTable allLocations = new Business.BL_Location().getAllLocationsForAdmin(user_id);

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
                            greenhouse_name = item["greenhouse_name"].ToString()
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
                    HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(new LocationListResponse()
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
                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(new LocationListResponse()
                {
                    success = false,
                    errorMessage = UniversalProperties.invalidRequest,
                    errorCode = UniversalProperties.EC_InvalidRequest,
                }));
            }

        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetGreenhouseLocationsByUserID(string user_id, string token)
        {
            token = token.Trim();

            if (new BL_User().validateTokenByUserID(user_id, token) == 1)
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
                            greenhouse_name = item["greenhouse_name"].ToString()
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
                    HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(new LocationListResponse()
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
                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(new LocationListResponse()
                {
                    success = false,
                    errorMessage = UniversalProperties.invalidRequest,
                    errorCode = UniversalProperties.EC_InvalidRequest,
                }));
            }

        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetGreenhousesByUserID(string user_id, string token)
        {
            token = token.Trim();

            if (new BL_User().validateTokenByUserID(user_id, token) == 1)
            {
                //LocationResponse response = new LocationResponse();
                try
                {
                    DataTable allGreenhouses = new Business.BL_Greenhouse().getAllGreenhouses(user_id);

                    List<GreenhouseResponse> greenhouseList = new List<GreenhouseResponse>();

                    foreach (DataRow item in allGreenhouses.Rows)
                    {
                        greenhouseList.Add(new GreenhouseResponse()
                        {
                            location_address = item["location_address"].ToString(),
                            latitude = item["latitude"].ToString(),
                            longitude = item["longitude"].ToString(),
                            location_name = item["location_name"].ToString(),
                            location_unique_id = item["location_unique_id"].ToString(),
                            location_id = item["location_id"].ToString(),
                            created_date_time = item["created_date_time"].ToString(),
                            greenhouse_id = item["greenhouse_id"].ToString(),
                            greenhouse_name = item["greenhouse_name"].ToString(),
                            greenhouse_unique_id = item["greenhouse_unique_id"].ToString(),
                            last_updated_date = item["last_updated_date"].ToString(),
                            pic_url = item["pic_url"].ToString()
                        });
                    }
                    HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(new GreenhouseListResponse()
                    {
                        success = true,
                        errorMessage = null,
                        listOfGreenhouses = greenhouseList
                    }));
                    return;
                }
                catch
                {
                    HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(new GreenhouseListResponse()
                    {
                        success = false,
                        errorCode = UniversalProperties.EC_UnhandledError,
                        errorMessage = UniversalProperties.unknownError
                    }));
                }
                //HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(response));

            }
            else
            {
                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(new GreenhouseListResponse()
                {
                    success = false,
                    errorMessage = UniversalProperties.invalidRequest,
                    errorCode = UniversalProperties.EC_InvalidRequest,
                }));
            }

        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetLatestGreenhouseDeviceDataByGreenhouseID(string user_id, string greenhouse_id, string token)
        {
            token = token.Trim();

            if (new BL_User().validateTokenByUserID(user_id, token) == 1 && new BL_Greenhouse().doesGreenhouseIDExist(greenhouse_id, user_id))
            {
                DataResponse response = new DataResponse();
                try
                {
                    DataTable latestData = new Business.BL_GreenhouseDeviceData().getLatestData(greenhouse_id);

                    List<DataResponse> dataList = new List<DataResponse>();

                    foreach (DataRow item in latestData.Rows)
                    {
                        dataList.Add(new DataResponse()
                        {
                            collected_time = item["collected_time"].ToString(),
                            data = item["data"].ToString(),
                            data_unit = item["data_unit"].ToString(),
                            device_unique_id = item["device_unique_id"].ToString(),
                            device_type = item["device_type"].ToString()
                        });
                    }
                    HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(new DataListResponse()
                    {
                        success = true,
                        errorMessage = null,
                        listOfData = dataList
                    }));
                    return;
                }
                catch
                {
                    HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(new DataListResponse()
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
                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(new DataListResponse()
                {
                    success = false,
                    errorMessage = UniversalProperties.invalidRequest,
                    errorCode = UniversalProperties.EC_InvalidRequest,
                }));
            }

        }
    }
}


