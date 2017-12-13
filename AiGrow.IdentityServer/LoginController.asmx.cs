using AiGrow.Business;
using AiGrow.Model;
using Facebook;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;


namespace AiGrow.IdentityServer
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://AiGrow.lk/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LoginController : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void CheckLoginPOSTJSON(string UserName, string Password, string token, string loginMode)
        {
            loginMode = loginMode.Trim();

            if (Encryption.createSHA1(UserName + Password) == token)
            {
                HttpContext.Current.Response.Write(LoginCoreJSON(UserName, Password, loginMode));
                //return LoginCoreJSON(UserName, Password, loginMode);
            }
            else
            {
                // return new JavaScriptSerializer().Serialize(new JSONReturn() { errorText = UniversalProperties.invalidRequest, value = UniversalProperties.INVALID, property = UniversalProperties.VALIDATE_LOGIN });
                // return new JavaScriptSerializer().Serialize(new LoginResponse() { success = false, errorMessage = UniversalProperties.invalidRequest, credentials = UniversalProperties.INVALID });
                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(new LoginResponse()
                {
                    success = false,
                    errorMessage = UniversalProperties.invalidRequest,
                    errorCode = UniversalProperties.EC_InvalidRequest,
                    credentials = UniversalProperties.INVALID
                }));
            }

        }


        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]

        public void LogOut(string loginID, string token)
        {
            BaseResponse returnObj = new BaseResponse();
            try
            {
                if (new BL_User().validateToken(token) == 1)
                {

                    if (new BL_Login().logOut(new ML_Login()
                    {
                        id_login = loginID.ToInt()
                    }) == 1)
                    {
                        returnObj.success = true;
                        returnObj.message = UniversalProperties.userSuccessfullyLoggedOut;
                    }
                    else
                    {
                        returnObj.success = false;
                        returnObj.message = UniversalProperties.invalidLoginID;
                        returnObj.errorCode = UniversalProperties.EC_InvalidLoginID;
                    }
                }
                else
                {
                    returnObj.success = false;
                    returnObj.message = UniversalProperties.invalidRequest;
                    returnObj.errorCode = UniversalProperties.EC_InvalidRequest;
                }
                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                return;
            }
            catch 
            {
                returnObj.success = false;
                returnObj.errorMessage = UniversalProperties.unhandledError;
                returnObj.errorCode = UniversalProperties.EC_UnhandledError;
                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                return;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ValidateTokenPOST(string token)
        {
            if (new BL_User().validateToken(token) == 1)
            {
                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(new BaseResponse() { success = true }));
            }
            else
            {
                // HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(new JSONReturn() { errorText = UniversalProperties.invalidToken, value = UniversalProperties.INVALID, property = UniversalProperties.VALIDATE_LOGIN }));
                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(new BaseResponse() { success = false, errorMessage = UniversalProperties.invalidToken, errorCode = UniversalProperties.EC_InvalidToken }));
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GetToken(string input)
        {
            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(new LoginResponse()
            {
                errorMessage = null,
                success = true,
                token = Encryption.createSHA1(input)
            }));
        }

        private static string LoginCoreJSON(string UserName, string Password, string loginMode)
        {
            //List<JSONReturn> returnObj = new List<JSONReturn>();
            LoginResponse returnObj = new LoginResponse();
            if (new AiGrow.Business.BL_User().doesUserExist(UserName))
            {
                string saltFromDb = new AiGrow.Business.BL_User().getUserSalt(new ML_User()
                {
                    username = UserName
                }).Rows[0][0].ToString();
                string userRole = new AiGrow.Business.BL_User().getUserRole(new ML_User()
                {
                    username = UserName
                });

                string[] encPassword = new CustomCryptography().encryptPassword(Password, saltFromDb);

                string password = encPassword[0];
                string salt = encPassword[1];

                DataTable loginTable = new AiGrow.Business.BL_User().checkLoginSecure(new ML_User()
                {
                    password = password,
                    username = UserName,
                    salt = salt
                });

                if (loginTable.Rows.Count == 1)
                {

                    //User is active. Proceed with login.
                    string tokenString = Encryption.createSHA1(loginMode + DateTime.Now.ToString() + UserName + Password);

                    string userIDString = loginTable.Rows[0]["id_user"].ToString();

                    int loginID = new BL_Login().insert(new ML_Login()
                    {
                        login_mode = loginMode,
                        login_token = tokenString,
                        id_user = userIDString.ToInt()
                    });

                    returnObj.credentials = UniversalProperties.VALID;
                    returnObj.token = tokenString;
                    returnObj.success = true;
                    returnObj.loginID = loginID.ToString();
                    returnObj.userName = UserName;
                    returnObj.userID = userIDString;
                    returnObj.userRole = userRole;
                }

                else
                {
                    returnObj.credentials = UniversalProperties.INVALID;
                    returnObj.success = false;
                    returnObj.errorMessage = UniversalProperties.userPassInvalid;
                    returnObj.errorCode = UniversalProperties.EC_UserPassInvalid;
                }
            }
            else
            {
                returnObj.credentials = UniversalProperties.INVALID;
                returnObj.success = false;
                returnObj.errorMessage = UniversalProperties.noSuchUserFound;
                returnObj.errorCode = UniversalProperties.EC_NoSuchUserFound;
            }
            return new JavaScriptSerializer().Serialize(returnObj);
        }
    }
}
