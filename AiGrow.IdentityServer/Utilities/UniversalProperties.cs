using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AiGrow.IdentityServer
{
    public class UniversalProperties
    {
        #region Configurations

        public const string required = "required";
        public const string validationNeeded = "needs_validation";
        public const string minimumPasswordLength = "minimum_password_length";
        public const string passwordAppendPortion = "@321";
        public const string certificate = "certificate";
        public const string customerSpecificEndpoint = "customer_specific_endpoint";
        public const string keystoreName = "keystore_name";
        public const string keystorePassword = "keystore_password";
        public const string privateKey = "private_key";
        public const string certificateID = "certificate_id";
        public const string countryList = "country_list";
        public const string titleList = "title_list";
        public const string welcomeEmailText = "welcome_email_text";
        public const string resetPasswordEmailText = "reset_password_email_text";
        public const string newSystemEmailText = "new_system_email_text";
        public const string value = "value";
        public const string welcomeSMSText = "welcome_sms_text";

        #endregion

        public const string SriLanka = "Sri Lanka";

        public const string passwordLengthInvalid = "The password length does not match the requirements.";
        public const string invalidRequest = "Invalid request.";
        public const string invalidEmail = "You have entered an invalid email. Please re-check!";
        public const string emailInvalid = "The email stored for user: <username> in our database is not valid. Please contact the chargeNET Support Team.";
        public const string invalidMobile = "You have entered an invalid mobile no. Please re-check!";
        public static string userExists = "Username is already in the system. Please enter a different username.";
        public static string noSuchUserFound = "The specified username is not available in the system. Please re-check!";
        public static string noSuchUserFoundOrPinIsIncorrect = "No such user found or PIN provided is incorrect. Please re-check!";
        public static string userAddedSuccesfully = "The user was added successfully.";
        public static string error = "ERROR";
        public static string userInsertionFailed = "There was an error in adding the user. Please contact the System Administrator.";
        public static string userActivatedSuccessfully = "The user was activated successfully.";
        public static string userUpdateFailed = "There was an error in updating user details. Please contact the System Administrator.";
        public static string userUpdatedSuccesfully = "The user details were updated successfully.";
        public static string requiredFieldsMissing = "One or more of the required fields are missing. Please re-check.";
        public static string invalidToken = "Invalid token.";
        public static string unhandledError = "An unhandled error occurred. Please contact chargeNET Support Team.";
        public static string welcomeSMS = "Dear <username>, thank you for signing up with chargeNET. Check your email to activate the account. Thank you.";
        public static string newSystemSMSText = "Introducing chargeNET 2.0, system upgrade to provide you with convenient EV charging. Please check your email or contact us for more details!";
        public const string userNotActive = "User is not in active state.";
        public const string deviceIDExists = "The specified device ID already exists for the given user.";
        public const string deviceIDAdded = "Device ID added for user.";

        //Login Modes
        public static string loginModeApp = "APP";
        public static string loginModeWeb = "WEB";
        public static string loginModeFacebook = "FACEBOOK";
        public static string loginModeGoogle = "GOOGLE";

        public static string credentialsValid = "VALID";
        public static string credentialsInvalid = "INVALID. PLEASE RE-CHECK!";
        public static string credentials = "CREDENTIALS";

        //User Constants
        public const string CHG_ADMIN = "CHG_ADMIN";
        public const string CHG_NETWORK = "CHG_NETWORK";
        public const string CHG_OWNER = "CHG_OWNER";
        public const string AIGROW_CUSTOMER = "AIGROW_CUSTOMER";
        public const string ACTIVE_USER = "ACTIVE_USER";
        public const string INACTIVE_USER = "INACTIVE_USER";
        public const string ONLINE = "ONLINE";
        public const string DUMMY_NFC_REF = "DUMMY_NFC_REF";

        public const string Username = "username";
        public const string Password = "password";
        public const string Mobile = "mobile";
        public const string Email = "email";

        //Portal Constants
        //public static string PORTAL_URL = ApplicationUtilities.ReadSetting("portal_url");

        //IS Constants
        public static string IS_PORT = ApplicationUtilities.ReadSetting("IdentityServerPort");
        public static string IS_HOST = ApplicationUtilities.ReadSetting("is_host");
        //public static string HOST_URL_IDENTITY_SERVER = string.Format("http://{0}:{1}/", IS_HOST, IS_PORT);
        public const string CREDENTIALS = "CREDENTIALS";
        public const string VALID = "VALID";
        public const string INVALID = "INVALID";
        public const string PASSWORD_UPDATE_STATUS = "PASSWORD_UPDATE_STATUS";
        public const string VALIDATE_LOGIN = "LOGIN_VALIDATE_REQUEST";
        public const string LOGIN_TOKEN = "LOGIN_TOKEN";
        public const string LOGIN_ID = "LOGIN_ID";
        public const string TOKEN_VALIDATION = "TOKEN_VALIDATION";
        public const string userPassInvalid = "The username and / or password is invalid. Please recheck!";
        public const string thirdPartyValidationFailed = "Third party validation has returned an error.";
        public const string userSuccessfullyLoggedOut = "The user was successfully logged out.";
        public const string invalidLoginID = "Invalid login ID supplied. Please re-check!";
        public const string emailSent = "Email sent.";
        public static string ACTIVATE_USER_URL = "UserController.asmx/ActivateUser";
        public static string ACTIVATE_USER_PORTAL_URL = "ActivateUser.aspx";
        public static string REQUEST_CHARGE_CARD_PORTAL_URL = "RequestChargeCard.aspx";

        //Email Constants
        public static string welcomeToChargeNET = "Welcome to chargeNET";
        public static string INFO_CHARGENET_EMAIL = ApplicationUtilities.ReadSetting("chargeNETInfoEmail");
        public static string INFO_CHARGENET_EMAIL_FROM = "chargeNET <" + ApplicationUtilities.ReadSetting("chargeNETInfoEmail") + ">";

        public static string INFO_CHARGENET_PASSWORD = ApplicationUtilities.ReadSetting("chargeNETInfoPassword");
        public static string GOOGLE_CHARGENET_EMAIL = ApplicationUtilities.ReadSetting("chargeNETGoogleEmail");
        public static string CHARGENET_LOGO_URL = ApplicationUtilities.ReadSetting("chargeNETLogoURL");
        public static string BOOTSTRAP_CDN_LINK = ApplicationUtilities.ReadSetting("BootstrapURL");

        //Transaction Server Links
        public static string TRS_PORT = ApplicationUtilities.ReadSetting("TransactionServerPort");
        //public static string HOST_URL_TRANSACTION_SERVER = string.Format("http://{0}:{1}/", HttpContext.Current.Request.Url.Host, TRS_PORT);
        public static string RELOAD_URL = "ReloadHandler.asmx/ReloadByCash";
        public static string SMS_URL = "SMSHandler.asmx/SendSMS";

        #region Error Codes

        public const int EC_NoError = 0;
        public const int EC_PasswordLengthInvalid = 1;
        public const int EC_InvalidRequest = 2;
        public const int EC_InvalidEmail = 3;
        public const int EC_InvalidMobile = 4;
        public const int EC_UserExists = 5;
        public const int EC_NoSuchUserFound = 6;
        public const int EC_UserInsertionFailed = 7;
        public const int EC_UserUpdateFailed = 8;
        public const int EC_InvalidToken = 9;
        public const int EC_RequiredFieldsMissing = 10;
        public const int EC_ThirdPartyValidationFailed = 11;
        public const int EC_UserPassInvalid = 12;
        public const int EC_UnhandledError = 13;
        public const int EC_ERROR_TEXT_INSUFFICIENT_BALANCE = 14;
        public const int EC_ERROR_TEXT_USER_OR_CHARGE_POINT_NOT_ACTIVE = 15;
        public const int EC_ERROR_TEXT_NOT_ALLOWED_TO_OTHERS = 16;
        public const int EC_MessageNotSent = 17;
        public const int EC_InvalidLoginID = 18;
        public const int EC_UserNotActive = 19;
        public const int EC_NoSuchUserFoundOrPinIsIncorrect = 20;
        public const int EC_InvalidPromotionID = 21;
        public const int EC_OperationSpecificError = 22;

        #endregion
    }
}