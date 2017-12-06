using AiGrow.Business;
using AiGrow.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
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
    public class UserController : System.Web.Services.WebService
    {

        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public void AddDeviceByUserID(string userID, string deviceID, string token)
        //{
        //    BaseResponse returnObj = new BaseResponse();
        //    userID = userID.Trim();
        //    try
        //    {
        //        if (new BL_User().validateToken(token) == 1 || Encryption.createSHA1(userID) == token)
        //        {
        //            int insertedRows = new BL_User().addDeviceID(new ML_User()
        //            {
        //                UserID = userID.ToInt(),
        //                DeviceID = deviceID
        //            });
        //            returnObj.success = true;
        //            if (insertedRows >= 1)
        //            {
        //                returnObj.message = UniversalProperties.deviceIDAdded;
        //            }
        //            else
        //            {
        //                returnObj.message = UniversalProperties.deviceIDExists;
        //            }
        //        }
        //        else
        //        {
        //            returnObj.success = false;
        //            returnObj.errorMessage = UniversalProperties.invalidRequest;
        //            returnObj.errorCode = UniversalProperties.EC_InvalidRequest;
        //        }
        //        HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
        //        return;
        //    }
        //    catch (Exception ex)
        //    {
        //        returnObj.success = false;
        //        returnObj.errorMessage = UniversalProperties.unhandledError;
        //        returnObj.errorCode = UniversalProperties.EC_UnhandledError;
        //        HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
        //        return;
        //    }
        //}

        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public void AddUser(string userName,string unique_id, string password, string token, string gender, string title, string mobile, string email, string organizationAddress, string organizationName, string telephone, string lastName, string firstName, string country, string address, string profilePicURL)
        //{
        //    BaseResponse returnObj = new BaseResponse();
        //    try
        //    {
        //        if (Encryption.createSHA1(userName + password) == token)
        //        {

        //            #region Required Field Validations

        //            List<string> required = new List<string>(new AiGrow.Business.BL_Configurations().getConfigValue(UniversalProperties.required).Rows[0][0].ToString().Split(new char[] { ';' }));

        //            if (required.Contains(UniversalProperties.Username) && userName.IsEmpty())
        //            {
        //                returnObj.success = false;
        //                returnObj.errorMessage = UniversalProperties.requiredFieldsMissing;
        //                returnObj.errorCode = UniversalProperties.EC_RequiredFieldsMissing;
        //                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
        //                return;
        //            }

        //            if (required.Contains(UniversalProperties.Password) && password.IsEmpty())
        //            {
        //                returnObj.success = false;
        //                returnObj.errorMessage = UniversalProperties.requiredFieldsMissing;
        //                returnObj.errorCode = UniversalProperties.EC_RequiredFieldsMissing;
        //                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
        //                return;
        //            }

        //            if (required.Contains(UniversalProperties.Mobile) && mobile.IsEmpty())
        //            {
        //                returnObj.success = false;
        //                returnObj.errorMessage = UniversalProperties.requiredFieldsMissing;
        //                returnObj.errorCode = UniversalProperties.EC_RequiredFieldsMissing;
        //                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
        //                return;
        //            }

        //            if (required.Contains(UniversalProperties.Email) && email.IsEmpty())
        //            {
        //                returnObj.success = false;
        //                returnObj.errorMessage = UniversalProperties.requiredFieldsMissing;
        //                returnObj.errorCode = UniversalProperties.EC_RequiredFieldsMissing;
        //                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
        //                return;
        //            }
        //            #endregion

        //            #region Data Validations
        //            //Do validations

        //            List<string> toBeValidated = new List<string>(new AiGrow.Business.BL_Configurations().getConfigValue(UniversalProperties.validationNeeded).Rows[0][0].ToString().Split(new char[] { ';' }));

        //            if (toBeValidated.Contains(UniversalProperties.Username))
        //            {
        //                if (new AiGrow.Business.BL_User().doesUserExist(userName))
        //                {
        //                    returnObj.success = false;
        //                    returnObj.errorMessage = UniversalProperties.userExists;
        //                    returnObj.errorCode = UniversalProperties.EC_UserExists;
        //                    HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
        //                    return;
        //                }

        //            }

        //            if (toBeValidated.Contains(UniversalProperties.Password))
        //            {
        //                int passwordLength = new AiGrow.Business.BL_Configurations().getConfigValue(UniversalProperties.minimumPasswordLength).Rows[0][0].ToString().ToInt();
        //                if (password.Length < passwordLength)
        //                {
        //                    returnObj.success = false;
        //                    returnObj.errorMessage = string.Format("{0} Please enter a password of at least {1} characters long.", UniversalProperties.passwordLengthInvalid, passwordLength);
        //                    returnObj.errorCode = UniversalProperties.EC_PasswordLengthInvalid;
        //                    HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
        //                    return;
        //                }
        //            }

        //            if (toBeValidated.Contains(UniversalProperties.Email))
        //            {
        //                Match m = Regex.Match(email, @"^[a-zA-Z0-9.!#$%&'*+=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", RegexOptions.IgnoreCase);
        //                if (!m.Success)
        //                {
        //                    returnObj.success = false;
        //                    returnObj.errorMessage = UniversalProperties.invalidEmail;
        //                    returnObj.errorCode = UniversalProperties.EC_InvalidEmail;
        //                    HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
        //                    return;
        //                }
        //            }

        //            if (toBeValidated.Contains(UniversalProperties.Mobile))
        //            {
        //                Match m = Regex.Match(mobile, "^[0-9|+]{10,12}$", RegexOptions.IgnoreCase);

        //                if (!m.Success)
        //                {
        //                    returnObj.success = false;
        //                    returnObj.errorMessage = UniversalProperties.invalidMobile;
        //                    returnObj.errorCode = UniversalProperties.EC_InvalidMobile;
        //                    HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
        //                    return;
        //                }
        //            }

        //            #endregion

        //            #region Database Insertion

        //            string[] userCredentials = new CustomCryptography().encryptPassword(password);
        //            password = userCredentials[0];
        //            string userSalt = userCredentials[1];

        //            int insertCustomer = new AiGrow.Business.BL_User().insert(new ML_User()
        //            {
        //                username = userName,
        //                user_unique_id = unique_id,
        //                address = address,
        //                country = country,
        //                email = email,
        //                first_name = firstName,
        //                gender = gender,
        //                last_name = lastName,
        //                mobile = mobile,
        //                organization_name = organizationAddress,
        //                password = password,
        //                role_id = new AiGrow.Business.BL_User().getRoleID(UniversalProperties.CHG_CUSTOMER).Rows[0][0].ToString().ToInt(),
        //                salt = userSalt,
        //                telephone = telephone,
        //                title = title,
        //                profile_picture_url = profilePicURL
        //            });

        //            string strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
        //            string hostUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/").Replace(ApplicationUtilities.ReadSetting("IdentityServerPort"), ApplicationUtilities.ReadSetting("TransactionServerPort"));

        //            string portalURLHost = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/").Replace(ApplicationUtilities.ReadSetting("IdentityServerPort"), "80");

        //            if (insertCustomer != -1)
        //            {
        //                returnObj.success = true;
        //                returnObj.message = insertCustomer.ToString();
        //                //returnObj.message = UniversalProperties.userAddedSuccesfully;
        //            }
        //            else
        //            {
        //                returnObj.success = false;
        //                returnObj.errorMessage = UniversalProperties.userInsertionFailed;
        //                returnObj.errorCode = UniversalProperties.EC_UserInsertionFailed;

        //            }
        //            #endregion
        //        }
        //        else
        //        {
        //            returnObj.success = false;
        //            returnObj.errorMessage = UniversalProperties.invalidRequest;
        //            returnObj.errorCode = UniversalProperties.EC_InvalidRequest;
        //        }
        //        HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
        //        return;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        returnObj.success = false;
        //        returnObj.errorMessage = UniversalProperties.unhandledError;
        //        returnObj.errorCode = UniversalProperties.EC_UnhandledError;
        //        HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
        //        return;
        //    }
        //}

        //private void sendSMS(string hostURL, string userID, string message, string mobileNo)
        //{
        //    RequestHandler post = new RequestHandler();
        //    post.Url = hostURL + UniversalProperties.SMS_URL;
        //    post.PostItems.Add("userID", userID);
        //    post.PostItems.Add("message", message);
        //    post.PostItems.Add("destination", mobileNo);
        //    post.PostItems.Add("token", Encryption.createSHA1(userID));
        //    post.Type = RequestHandler.PostTypeEnum.Post;
        //    string result = post.Post();
        //}

        //private void sendWelcomeEmail(string URL, string email, string userName, string userID)
        //{
        //    string activationLink = URL + UniversalProperties.ACTIVATE_USER_PORTAL_URL + "?userID=" + userID  + "&token=";

        //    string chargeCardRequestLink = URL + UniversalProperties.REQUEST_CHARGE_CARD_PORTAL_URL + "?userID=" + userID + "&token=" + Encryption.createSHA1(userID);

        //    string messageEmail = new BL_Configurations().getConfigValue(UniversalProperties.welcomeEmailText).Rows[0][0].ToString();

        //    messageEmail = messageEmail.Replace("{0}", userName).Replace("{1}", activationLink).Replace("{3}", chargeCardRequestLink);

        //    Mailer welcomeMail = new Mailer(UniversalProperties.INFO_AiGrow_EMAIL, UniversalProperties.INFO_AiGrow_PASSWORD, true);

        //    welcomeMail.sendEmail(UniversalProperties.INFO_AiGrow_EMAIL_FROM, email.Trim(), UniversalProperties.welcomeToAiGrow, messageEmail);
        //}

        //private void sendNewSystemEmail(string email, string userName, string userID)
        //{
        //    string strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;

        //    string portalURLHost = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/").Replace(ApplicationUtilities.ReadSetting("IdentityServerPort"), "80");

        //    string resetPasswordLink = string.Format("{0}Dashboards/ResetPassword.aspx?username={1}&token_email={2}&email={3}&userID={4}", portalURLHost, Encryption.Base64Encode(userName), Encryption.Base64Encode(email), email, Encryption.Base64Encode(userID));

        //    string messageEmail = new BL_Configurations().getConfigValue(UniversalProperties.newSystemEmailText).Rows[0][0].ToString();

        //    messageEmail = messageEmail.Replace("{0}", userName).Replace("{1}", resetPasswordLink);

        //    Mailer welcomeMail = new Mailer(UniversalProperties.INFO_AiGrow_EMAIL, UniversalProperties.INFO_AiGrow_PASSWORD, true);

        //    welcomeMail.sendEmail(UniversalProperties.INFO_AiGrow_EMAIL_FROM, email.Trim(), UniversalProperties.welcomeToAiGrow, messageEmail);
        //}

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetUserID(string uniqueID)
        {
            BaseResponse returnObj = new BaseResponse();
            try
            {
                string userID = new BL_User().getUserIDByReference(uniqueID);
                returnObj.success = true;
                returnObj.message = userID;
                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                return;
            }
            catch (Exception e)
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
        public void AddUserJSON(string userName, string password, string token, string gender, string title, string mobile, string email, string organizationName, string telephone, string lastName, string firstName, string country, string address, string profilePicURL, string role)
        {
            BaseResponse returnObj = new BaseResponse();
            try
            {
                if (Encryption.createSHA1(userName + password) == token)
                {

                    #region Required Field Validations

                    List<string> required = new List<string>(new AiGrow.Business.BL_Configurations().getConfigValue(UniversalProperties.required).Rows[0][0].ToString().Split(new char[] { ';' }));

                    if (required.Contains(UniversalProperties.Username) && userName.IsEmpty())
                    {
                        returnObj.success = false;
                        returnObj.errorMessage = UniversalProperties.requiredFieldsMissing;
                        returnObj.errorCode = UniversalProperties.EC_RequiredFieldsMissing;
                        HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                        return;
                    }

                    if (required.Contains(UniversalProperties.Password) && password.IsEmpty())
                    {
                        returnObj.success = false;
                        returnObj.errorMessage = UniversalProperties.requiredFieldsMissing;
                        returnObj.errorCode = UniversalProperties.EC_RequiredFieldsMissing;
                        HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                        return;
                    }

                    if (required.Contains(UniversalProperties.Mobile) && mobile.IsEmpty())
                    {
                        returnObj.success = false;
                        returnObj.errorMessage = UniversalProperties.requiredFieldsMissing;
                        returnObj.errorCode = UniversalProperties.EC_RequiredFieldsMissing;
                        HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                        return;
                    }

                    if (required.Contains(UniversalProperties.Email) && email.IsEmpty())
                    {
                        returnObj.success = false;
                        returnObj.errorMessage = UniversalProperties.requiredFieldsMissing;
                        returnObj.errorCode = UniversalProperties.EC_RequiredFieldsMissing;
                        HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                        return;
                    }
                    #endregion

                    #region Data Validations
                    //Do validations

                    List<string> toBeValidated = new List<string>(new AiGrow.Business.BL_Configurations().getConfigValue(UniversalProperties.validationNeeded).Rows[0][0].ToString().Split(new char[] { ';' }));

                    if (toBeValidated.Contains(UniversalProperties.Username))
                    {
                        if (new AiGrow.Business.BL_User().doesUserExist(userName))
                        {
                            returnObj.success = false;
                            returnObj.errorMessage = UniversalProperties.userExists;
                            returnObj.errorCode = UniversalProperties.EC_UserExists;
                            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                            return;
                        }

                    }

                    if (toBeValidated.Contains(UniversalProperties.Password))
                    {
                        int passwordLength = new AiGrow.Business.BL_Configurations().getConfigValue(UniversalProperties.minimumPasswordLength).Rows[0][0].ToString().ToInt();
                        if (password.Length < passwordLength)
                        {
                            returnObj.success = false;
                            returnObj.errorMessage = string.Format("{0} Please enter a password of at least {1} characters long.", UniversalProperties.passwordLengthInvalid, passwordLength);
                            returnObj.errorCode = UniversalProperties.EC_PasswordLengthInvalid;
                            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                            return;
                        }
                    }

                    if (toBeValidated.Contains(UniversalProperties.Email))
                    {
                        Match m = Regex.Match(email, @"^[a-zA-Z0-9.!#$%&'*+=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", RegexOptions.IgnoreCase);
                        if (!m.Success)
                        {
                            returnObj.success = false;
                            returnObj.errorMessage = UniversalProperties.invalidEmail;
                            returnObj.errorCode = UniversalProperties.EC_InvalidEmail;
                            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                            return;
                        }
                    }

                    if (toBeValidated.Contains(UniversalProperties.Mobile))
                    {
                        Match m = Regex.Match(mobile, "^[0-9|+]{10,12}$", RegexOptions.IgnoreCase);

                        if (!m.Success)
                        {
                            returnObj.success = false;
                            returnObj.errorMessage = UniversalProperties.invalidMobile;
                            returnObj.errorCode = UniversalProperties.EC_InvalidMobile;
                            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                            return;
                        }
                    }

                    #endregion

                    #region Database Insertion

                    string[] userCredentials = new CustomCryptography().encryptPassword(password);
                    password = userCredentials[0];
                    string userSalt = userCredentials[1];

                    int insertCustomer = new AiGrow.Business.BL_User().insert(new ML_User()
                    {
                        username = userName,
                        address = address,
                        country = country,
                        email = email,
                        first_name = firstName,
                        gender = gender,
                        last_name = lastName,
                        mobile = mobile,
                        organization_name = organizationName,
                        password = password,
                        role_id = new AiGrow.Business.BL_User().getRoleID(role).Rows[0][0].ToString().ToInt(),
                        salt = userSalt,
                        telephone = telephone,
                        title = title,
                        profile_picture_url = profilePicURL
                    });

                    if (insertCustomer != -1)
                    {
                        returnObj.success = true;
                        returnObj.message = UniversalProperties.userAddedSuccesfully;
                    }
                    else
                    {
                        returnObj.success = false;
                        returnObj.errorMessage = UniversalProperties.userInsertionFailed;
                        returnObj.errorCode = UniversalProperties.EC_UserInsertionFailed;

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
            catch (System.Exception ex)
            {
                returnObj.success = false;
                returnObj.errorMessage = UniversalProperties.unhandledError;
                returnObj.errorCode = UniversalProperties.EC_UnhandledError;
                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                return;
            }
        }


        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public void UpdateUserImageJSON(string userName, string image, string token)
        //{
        //    UserResponse returnObj = new UserResponse();

        //    if (new BL_User().validateToken(token) == 1)
        //    {
        //        Image img = ApplicationUtilities.Base64ToImage(image);

        //    }
        //    else
        //    {
        //        returnObj.success = false;
        //        returnObj.errorMessage = UniversalProperties.invalidRequest;
        //        returnObj.errorCode = UniversalProperties.EC_InvalidRequest;
        //    }
        //    HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
        //    return;
        //}

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetCustomerJSON(string userName, string token)
        {
            UserResponse returnObj = new UserResponse();

            if (new BL_User().validateToken(token) == 1)
            {
                DataTable customer = new AiGrow.Business.BL_User().selectCustomer(new ML_User()
                {
                    username = userName.Trim(),
                }, token.Trim());
                if (customer.Rows.Count == 1)
                {
                    returnObj.success = true;
                    returnObj.address = customer.Rows[0]["address"].ToString();
                    returnObj.title = customer.Rows[0]["title"].ToString();
                    returnObj.first_name = customer.Rows[0]["first_name"].ToString();
                    returnObj.gender = customer.Rows[0]["gender"].ToString();
                    returnObj.last_name = customer.Rows[0]["last_name"].ToString();
                    returnObj.email = customer.Rows[0]["email"].ToString();
                    returnObj.telephone = customer.Rows[0]["telephone"].ToString();
                    returnObj.mobile = customer.Rows[0]["mobile"].ToString();
                    returnObj.organization_name = customer.Rows[0]["organization_name"].ToString();
                    returnObj.country = customer.Rows[0]["country"].ToString();
                    returnObj.username = customer.Rows[0]["username"].ToString();
                    returnObj.profile_pic_url = customer.Rows[0]["profile_picture_url"].ToString();
                }
                else
                {
                    returnObj.success = false;
                    returnObj.errorMessage = UniversalProperties.noSuchUserFound;
                    returnObj.errorCode = UniversalProperties.EC_NoSuchUserFound;
                }
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void UpdateCustomerJSON(string userID, string password, string token, string gender, string title, string mobile, string email, string organizationName, string telephone, string lastName, string firstName, string country, string address, string picURL)
        {
            BaseResponse returnObj = new BaseResponse();

            try
            {
                if (new BL_User().validateToken(token.Trim()) == 1)
                {
                    #region Required Field Validations

                    List<string> required = new List<string>(new AiGrow.Business.BL_Configurations().getConfigValue(UniversalProperties.required).Rows[0][0].ToString().Split(new char[] { ';' }));


                    if (required.Contains(UniversalProperties.Mobile) && mobile.IsEmpty())
                    {
                        returnObj.success = false;
                        returnObj.errorMessage = UniversalProperties.requiredFieldsMissing;
                        returnObj.errorCode = UniversalProperties.EC_RequiredFieldsMissing;
                        HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                        return;
                    }

                    if (required.Contains(UniversalProperties.Email) && email.IsEmpty())
                    {
                        returnObj.success = false;
                        returnObj.errorMessage = UniversalProperties.requiredFieldsMissing;
                        returnObj.errorCode = UniversalProperties.EC_RequiredFieldsMissing;
                        HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                        return;
                    }
                    #endregion

                    #region Data Validations
                    //Do validations

                    List<string> toBeValidated = new List<string>(new AiGrow.Business.BL_Configurations().getConfigValue(UniversalProperties.validationNeeded).Rows[0][0].ToString().Split(new char[] { ';' }));

                    if (toBeValidated.Contains(UniversalProperties.Password))
                    {
                        int passwordLength = new AiGrow.Business.BL_Configurations().getConfigValue(UniversalProperties.minimumPasswordLength).Rows[0][0].ToString().ToInt();
                        if (password.Length < passwordLength)
                        {
                            returnObj.success = false;
                            returnObj.errorMessage = string.Format("{0} Please enter a password of at least {1} characters long.", UniversalProperties.passwordLengthInvalid, passwordLength);
                            returnObj.errorCode = UniversalProperties.EC_PasswordLengthInvalid;
                            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                            return;
                        }
                    }

                    if (toBeValidated.Contains(UniversalProperties.Email))
                    {
                        Match m = Regex.Match(email, @"^[a-zA-Z0-9.!#$%&'*+=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", RegexOptions.IgnoreCase);
                        if (!m.Success)
                        {
                            returnObj.success = false;
                            returnObj.errorMessage = UniversalProperties.invalidEmail;
                            returnObj.errorCode = UniversalProperties.EC_InvalidEmail;
                            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                            return;
                        }
                    }

                    if (toBeValidated.Contains(UniversalProperties.Mobile))
                    {
                        Match m = Regex.Match(mobile, "^[0-9|+]{10,12}$", RegexOptions.IgnoreCase);

                        if (!m.Success)
                        {
                            returnObj.success = false;
                            returnObj.errorMessage = UniversalProperties.invalidMobile;
                            returnObj.errorCode = UniversalProperties.EC_InvalidMobile;
                            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                            return;
                        }
                    }

                    #endregion

                    #region Database Insertion

                    string userSalt = null;

                    if (password.IsNotEmpty())
                    {
                        string[] userCredentials = new CustomCryptography().encryptPassword(password);
                        password = userCredentials[0];
                        userSalt = userCredentials[1];
                    }


                    int updateCustomer = new AiGrow.Business.BL_User().update(new ML_User()
                    {
                        id_user = userID.ToInt(),
                        address = address,
                        country = country,
                        email = email,
                        first_name = firstName,
                        gender = gender,
                        last_name = lastName,
                        mobile = mobile,
                        organization_name = organizationName,
                        password = password.IsEmpty() ? null : password,
                        role_id = new AiGrow.Business.BL_User().getRoleID(UniversalProperties.AIGROW_CUSTOMER).Rows[0][0].ToString().ToInt(),
                        salt = password.IsEmpty() ? null : userSalt,
                        telephone = telephone,
                        title = title,
                        profile_picture_url = picURL,
                    });

                    if (updateCustomer != -1)
                    {
                        returnObj.success = true;
                        returnObj.message = UniversalProperties.userUpdatedSuccesfully;
                    }
                    else
                    {
                        returnObj.success = false;
                        returnObj.errorMessage = UniversalProperties.userUpdateFailed;
                        returnObj.errorCode = UniversalProperties.EC_UserUpdateFailed;
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
                returnObj.errorMessage = UniversalProperties.unhandledError;
                returnObj.errorCode = UniversalProperties.EC_UnhandledError;
                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                return;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void UpdateCustomerAllFieldsJSON(string userID, string password, string token, string gender, string title, string mobile, string email, string organizationAddress, string organizationName, string telephone, string lastName, string firstName, string country, string address, string picURL, string status, string rfid)
        {
            BaseResponse returnObj = new BaseResponse();

            try
            {
                if (new BL_User().validateToken(token.Trim()) == 1)
                {
                    #region Required Field Validations

                    List<string> required = new List<string>(new AiGrow.Business.BL_Configurations().getConfigValue(UniversalProperties.required).Rows[0][0].ToString().Split(new char[] { ';' }));


                    if (required.Contains(UniversalProperties.Mobile) && mobile.IsEmpty())
                    {
                        returnObj.success = false;
                        returnObj.errorMessage = UniversalProperties.requiredFieldsMissing;
                        returnObj.errorCode = UniversalProperties.EC_RequiredFieldsMissing;
                        HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                        return;
                    }

                    if (required.Contains(UniversalProperties.Email) && email.IsEmpty())
                    {
                        returnObj.success = false;
                        returnObj.errorMessage = UniversalProperties.requiredFieldsMissing;
                        returnObj.errorCode = UniversalProperties.EC_RequiredFieldsMissing;
                        HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                        return;
                    }
                    #endregion

                    #region Data Validations
                    //Do validations

                    List<string> toBeValidated = new List<string>(new AiGrow.Business.BL_Configurations().getConfigValue(UniversalProperties.validationNeeded).Rows[0][0].ToString().Split(new char[] { ';' }));

                    if (toBeValidated.Contains(UniversalProperties.Password))
                    {
                        int passwordLength = new AiGrow.Business.BL_Configurations().getConfigValue(UniversalProperties.minimumPasswordLength).Rows[0][0].ToString().ToInt();
                        if (password.Length < passwordLength)
                        {
                            returnObj.success = false;
                            returnObj.errorMessage = string.Format("{0} Please enter a password of at least {1} characters long.", UniversalProperties.passwordLengthInvalid, passwordLength);
                            returnObj.errorCode = UniversalProperties.EC_PasswordLengthInvalid;
                            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                            return;
                        }
                    }

                    if (toBeValidated.Contains(UniversalProperties.Email))
                    {
                        Match m = Regex.Match(email, @"^[a-zA-Z0-9.!#$%&'*+=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", RegexOptions.IgnoreCase);
                        if (!m.Success)
                        {
                            returnObj.success = false;
                            returnObj.errorMessage = UniversalProperties.invalidEmail;
                            returnObj.errorCode = UniversalProperties.EC_InvalidEmail;
                            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                            return;
                        }
                    }

                    if (toBeValidated.Contains(UniversalProperties.Mobile))
                    {
                        Match m = Regex.Match(mobile, "^[0-9|+]{10,12}$", RegexOptions.IgnoreCase);

                        if (!m.Success)
                        {
                            returnObj.success = false;
                            returnObj.errorMessage = UniversalProperties.invalidMobile;
                            returnObj.errorCode = UniversalProperties.EC_InvalidMobile;
                            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                            return;
                        }
                    }

                    #endregion

                    #region Database Insertion

                    string userSalt = null;

                    if (password.IsNotEmpty())
                    {
                        string[] userCredentials = new CustomCryptography().encryptPassword(password);
                        password = userCredentials[0];
                        userSalt = userCredentials[1];
                    }


                    int updateCustomer = new AiGrow.Business.BL_User().update(new ML_User()
                    {
                        id_user = userID.ToInt(),
                        address = address,
                        country = country,
                        email = email,
                        first_name = firstName,
                        gender = gender,
                        last_name = lastName,
                        mobile = mobile,
                        organization_name = organizationName,
                        password = password.IsEmpty() ? null : password,
                        role_id = new AiGrow.Business.BL_User().getRoleID(UniversalProperties.AIGROW_CUSTOMER).Rows[0][0].ToString().ToInt(),
                        salt = password.IsEmpty() ? null : userSalt,
                        telephone = telephone,
                        title = title,
                        profile_picture_url = picURL,
                    });

                    if (updateCustomer != -1)
                    {
                        returnObj.success = true;
                        returnObj.message = UniversalProperties.userUpdatedSuccesfully;
                    }
                    else
                    {
                        returnObj.success = false;
                        returnObj.errorMessage = UniversalProperties.userUpdateFailed;
                        returnObj.errorCode = UniversalProperties.EC_UserUpdateFailed;
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
                returnObj.errorMessage = UniversalProperties.unhandledError;
                returnObj.errorCode = UniversalProperties.EC_UnhandledError;
                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                return;
            }
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void CheckUserNameJSON(string userName)
        {
            BaseResponse returnObj = new BaseResponse();

            if (new AiGrow.Business.BL_User().doesUserExist(userName))
            {
                returnObj.success = true;
                returnObj.message = true.ToString();
                returnObj.errorMessage = UniversalProperties.userExists;
                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                return;
            }
            else
            {
                returnObj.success = true;
                returnObj.message = false.ToString();
                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                return;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void GetUserIDByReference(string userReferenceID, string token)
        {
            BaseResponse returnObj = new BaseResponse();
            try
            {
                if (Encryption.createSHA1(userReferenceID.Trim()) == token)
                {
                    string userID = new BL_User().getUserIDByReference(userReferenceID);
                    returnObj.success = true;
                    returnObj.message = userID;
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
            catch (Exception e)
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
        public void GetUserIDByUsername(string userName, string token)
        {
            BaseResponse returnObj = new BaseResponse();
            try
            {
                if (Encryption.createSHA1(userName.Trim()) == token)
                {
                    string userID = new BL_User().getUserIDByUserName(userName);
                    returnObj.success = true;
                    returnObj.message = userID;
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
                returnObj.errorMessage = UniversalProperties.unhandledError;
                returnObj.errorCode = UniversalProperties.EC_UnhandledError;
                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                return;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void DoesEmailExist(string email, string token)
        {
            BaseResponse returnObj = new BaseResponse();
            try
            {
                if (new BL_User().validateToken(token) == 1 || Encryption.createSHA1(email.Trim()) == token)
                {
                    returnObj.message = new BL_User().doesEmailExist(email) == true ? true.ToString() : false.ToString();
                    returnObj.success = true;
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
                returnObj.errorMessage = UniversalProperties.unhandledError;
                returnObj.errorCode = UniversalProperties.EC_UnhandledError;
                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                return;
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void IsDuplicateEmail(string userID, string email, string token)
        {
            BaseResponse returnObj = new BaseResponse();
            try
            {
                if (new BL_User().validateToken(token) == 1 || Encryption.createSHA1(email.Trim()) == token)
                {
                    using (DataTable dt = new BL_User().selectRecordsByEmail(email))
                    {
                        switch (dt.Rows.Count)
                        {
                            case 0:
                                //No record exists at all.
                                returnObj.message = false.ToString();
                                break;
                            case 1:
                                //There is one record with the email supplied. Need to check if it's associated with the same user ID.
                                returnObj.message = (dt.Rows[0]["iduser"].ToString() == userID.ToString()) ? false.ToString() : true.ToString();
                                break;
                            default:
                                //There is more than one record with the email supplied. Invalid at all costs.
                                returnObj.message = true.ToString();
                                break;
                        }
                    }
                    returnObj.success = true;
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
                returnObj.errorMessage = UniversalProperties.unhandledError;
                returnObj.errorCode = UniversalProperties.EC_UnhandledError;
                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
                return;
            }
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void ResendActivationEmail(string userName, string userID = null)
        {
            BaseResponse returnObj = new BaseResponse();
            DataTable dt = new DataTable();
            try
            {
                if (userID != null && userID != string.Empty)
                {
                    //Select by userID
                    dt = new BL_User().selectByUserID(new ML_User()
                    {
                        id_user = userID.ToInt()
                    });
                    userName = dt.Rows.Count == 1 ? dt.Rows[0]["username"].ToString() : string.Empty;
                }
                else
                {
                    dt = new BL_User().selectByUserName(new ML_User()
                    {
                        username = userName
                    });
                }

                if (dt.Rows.Count == 1)
                {
                    string pin = dt.Rows[0]["activation_pin"].ToString();
                    string email = dt.Rows[0]["email"].ToString();
                    string user_id = dt.Rows[0]["iduser"].ToString();

                    string strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;

                    string portalURLHost = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/").Replace(ApplicationUtilities.ReadSetting("IdentityServerPort"), "80");

                    if (ApplicationUtilities.IsValidEmail(email))
                    {
                        returnObj.message = UniversalProperties.emailSent;
                        returnObj.success = true;
                    }
                    else
                    {
                        returnObj.success = false;
                        returnObj.errorMessage = UniversalProperties.emailInvalid.Replace("<username>", userName);
                        returnObj.errorCode = UniversalProperties.EC_InvalidEmail;
                    }
                }
                else
                {
                    returnObj.success = false;
                    returnObj.errorMessage = UniversalProperties.noSuchUserFound;
                    returnObj.errorCode = UniversalProperties.EC_NoSuchUserFound;
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


        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public void SendNewSystemEmail(string token, string userID = null)
        //{
        //    BaseResponse returnObj = new BaseResponse();
        //    DataTable userEmailAndMobile = new DataTable();
        //    try
        //    {
        //        if (new BL_User().validateToken(token) == 1 || Encryption.createSHA1(userID.Trim()) == token)
        //        {

        //            if (userID != null && userID != string.Empty)
        //            {
        //                //Select by userID
        //                userEmailAndMobile = new BL_User().selectByUserID(new ML_User()
        //                {
        //                    id_user = userID.ToInt()
        //                });
        //            }
        //            else
        //            {
        //                userEmailAndMobile = new BL_User().selectAllByEmailAndMobile();
        //            }

        //            string strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;

        //            string hostUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/").Replace(ApplicationUtilities.ReadSetting("IdentityServerPort"), ApplicationUtilities.ReadSetting("TransactionServerPort"));

        //            string messageToSend = UniversalProperties.newSystemSMSText;

        //            using (userEmailAndMobile)
        //            {
        //                foreach (DataRow item in userEmailAndMobile.Rows)
        //                {
        //                    string email = item["email"].ToString();
        //                    string mobile = item["mobile"].ToString();
        //                    string username = item["username"].ToString();
        //                    string userid = item["iduser"].ToString();
        //                    if (ApplicationUtilities.IsValidEmail(email))
        //                    {
        //                        sendNewSystemEmail(email, username, userid);
        //                        sendSMS(hostUrl, userid, messageToSend, mobile.Trim());
        //                        Thread.Sleep(2000);
        //                    }
        //                }
        //            }
        //            returnObj.success = true;
        //            returnObj.message = UniversalProperties.emailSent;

        //            HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
        //            return;
        //        }
        //        else
        //        {
        //            returnObj.success = false;
        //            returnObj.errorMessage = UniversalProperties.invalidRequest;
        //            returnObj.errorCode = UniversalProperties.EC_InvalidRequest;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        returnObj.success = false;
        //        returnObj.errorMessage = UniversalProperties.unhandledError;
        //        returnObj.errorCode = UniversalProperties.EC_UnhandledError;
        //        HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(returnObj));
        //        return;
        //    }

        //}
    }
}
