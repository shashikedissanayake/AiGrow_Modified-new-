/*
* ***----****----****----****----****
 Author: Sidath Gajanayaka
 © 2015-2017 - SG Creations
 All Rights Reserved. Licensed for use within chargeNET Pvt. Ltd.
 scgcreations@gmail.com
* ***----****----****----****----****
*/
using System;
using System.Web;

namespace AiGrow
{
    public class Constants
    {
        //User Constants
        public const String AIGROW_ADMIN = "ADMIN";
        public const String CHG_NETWORK = "HOME_USER";
        public const String CHG_OWNER = "CHG_OWNER";
        public const String AIGROW_CUSTOMER = "CUSTOMER";
        public const String CHG_STAFF = "CHG_STAFF";
        public const String CHG_ACCOUNTANT = "CHG_ACCOUNTANT";

        public static string MySQLDateFormat = "yyyy-MM-dd HH:mm:ss";

        public const String HEAD_OFFICE = "HEAD_OFFICE";

        public const String ACTIVE_USER = "ACTIVE_USER";
        public const String INACTIVE_USER = "INACTIVE_USER";
        public const String ONLINE = "ONLINE";
        public const String DUMMY_NFC_REF = "DUMMY_NFC_REF";
        public static string Username = "Username";

        //Charge Requests
        public static string PENDING = "PENDING";
        public static string COMPLETE = "COMPLETE";
        public static string CANCELLED = "CANCELLED";

        //Charger Protocols
        public static string PROTOCOL_J1772 = "J1772";
        public static string PROTOCOL_CHARDEMO = "CHARDEMO";

        //Charge Point Availability
        public const string AVAILABLE = "AVAILABLE";
        public const string UNAVAILABLE = "UNAVAILABLE";
        public const string OCCUPIED = "OCCUPIED";
        //public static string ACTIVE = "ACTIVE";
        //public static string BLOCKED = "BLOCKED";

        //Charge Point Power Status
        //public static string POWER_ON = "ON";
        //public static string POWER_OFF = "OFF";

        //HTTP session timeout
        public const int SESSIONTIMEOUT = 180;

        //Charge Point Type
        public static string LEVEL2 = "L2";
        //public static string LEVEL3 = "L3";
        public static string FAST = "FAST";

        //Paths & Common
        public static string HOME_URL = "index.aspx";
        public static string HOST_URL = string.Format("http://{0}:{1}/", HttpContext.Current.Request.Url.Host, HttpContext.Current.Request.Url.Port);
        //"http://localhost:10000/";
        public static string HOME_PATH_DASHBOARDS_ADMIN = HOST_URL + "Dashboards/Admin/";
        public static string HOME_PATH_DASHBOARDS_CUSTOMER = HOST_URL + "Dashboards/Customer/";
        public static string HOME_PATH_DASHBOARDS_NETWORK_OWNER = HOST_URL + "Dashboards/NetworkOwner/";
        public static string HOME_PATH_DASHBOARDS_CHARGE_POINT_OWNER = HOST_URL + "Dashboards/PointOwner/";
        public static string HOME_PATH_DASHBOARDS_STAFF = HOST_URL + "Dashboards/Staff/";
        public static string HOME_PATH_DASHBOARDS_ACCOUNTANT = HOST_URL + "Dashboards/Accountant/";

        public static string HOME_PATH_DASHBOARDS = HOST_URL + "Dashboards/";
        public static string LOG_OUT_URL = HOST_URL + "/Logout.aspx";
        public static string PROFILE_IMAGE_PATH = HOST_URL + "Dashboards/dist/img/";

        public static string VIEW_PROFILE_URL = HOST_URL + "Dashboards/ViewProfile.aspx";
        public static string RESET_PASSWORD = HOST_URL + "Dashboards/ResetPassword.aspx";
        public static string LOGIN_URL = HOST_URL + "Login.aspx";
        public static string FAVICON_URL = AppFunction.ReadSetting("FaviconURL");
        public static string CHARGENET_LOGO_URL = AppFunction.ReadSetting("chargeNETLogoURL");
        public static string BOOTSTRAP_CDN_LINK = AppFunction.ReadSetting("BootstrapURL");
        public static string CONTACT_US_TEXT = "<address>chargeNET Pvt. Ltd.,<br> Trace Expert City,<br> Tripoli Square,<br> Maradana,<br> Colombo 10.<br> </address><p>Tel. No.: +94 115 551 551<br> E-Mail: <a href=\"mailto:info@chargenet.lk\">info@chargenet.lk</a> </p>";
        public static string CHARGENET_LOGO_WITH_TEXT_URL = AppFunction.ReadSetting("chargeNETLogoWithURL");
        public static string INFO_CHARGENET_EMAIL = AppFunction.ReadSetting("chargeNETInfoEmail");
        public static string INFO_CHARGENET_EMAIL_FROM = "chargeNET <" + AppFunction.ReadSetting("chargeNETInfoEmail") + ">";

        public static string PORTAL_URL = AppFunction.ReadSetting("portal_url");
        public static string INFO_CHARGENET_PASSWORD = AppFunction.ReadSetting("chargeNETInfoPassword");
        public static string GOOGLE_CHARGENET_EMAIL = AppFunction.ReadSetting("chargeNETGoogleEmail");
        public static string FORGOT_PASSWORD_LINK = HOST_URL + "ForgotPassword.aspx";
        public static string REGISTER_URL = HOST_URL + "signUp.aspx";

        //Admin Dashboard Links
        public static String ADMIN_DASHBOARD_GREEN_HOUSE_EDIT = HOST_URL + "Dashboards/Admin/AdminEditGreenHouse.aspx";
        public static String ADMIN_DASHBOARD_GREEN_HOUSE_DELETE = HOST_URL + "Dashboards/Admin/AdminDeleteNetwork.aspx";   
        public static String ADMIN_DASHBOARD_GREEN_HOUSE = HOST_URL + "/Dashboards/Admin/AdminGreenHouses.aspx";
        public static string ADMIN_DASHBOARD_VIEW_GREEN_HOUSE = HOST_URL + "Dashboards/Admin/AdminGreenHouseView.aspx";
        public static string ADMIN_DASHBOARD_DATA_VISUALIZER = HOST_URL + "Dashboards/Admin/AdminDataVisualizer.aspx";


        public static String ADMIN_DASHBOARD_CHG_POINTS = HOST_URL + "Dashboards/Admin/AdminPoints.aspx";
        public static String ADMIN_DASHBOARD_CHG_POINTS_DELETE = HOST_URL + "Dashboards/Admin/AdminDeletePoint.aspx";
        public static String ADMIN_DASHBOARD_CHG_CUSTOMERS_DELETE = HOST_URL + "Dashboards/Admin/AdminDeleteCustomer.aspx";
        public static String ADMIN_DASHBOARD_CHG_NETWORK_OWNERS = HOST_URL + "Dashboards/Admin/AdminNetworkOwners.aspx";
        public static String ADMIN_DASHBOARD_CREATE_NETWORK_OWNER = HOST_URL + "Dashboards/Admin/AdminCreateNetworkOwner.aspx";
        public static String ADMIN_DASHBOARD_DELETE_NETWORK_OWNER = HOST_URL + "Dashboards/Admin/AdminDeleteNetworkOwner.aspx";
        public static String ADMIN_DASHBOARD_CREATE_POINT_OWNER = HOST_URL + "Dashboards/Admin/AdminCreatePointOwner.aspx";
        public static String ADMIN_DASHBOARD_DELETE_POINT_OWNER = HOST_URL + "Dashboards/Admin/AdminDeletePointOwner.aspx";

        public static String ADMIN_DASHBOARD_CREATE_CUSTOMER = HOST_URL + "Dashboards/Admin/AdminCreateCustomer.aspx";
        public static String ADMIN_DASHBOARD_CREATE_LOCATION = HOST_URL + "Dashboards/Admin/AdminCreateLocation.aspx";
        public static String ADMIN_DASHBOARD_CHG_POINT_OWNERS = HOST_URL + "Dashboards/Admin/AdminPointOwners.aspx";
        public static String ADMIN_DASHBOARD_CHG_CUSTOMERS = HOST_URL + "Dashboards/Admin/AdminCustomers.aspx";
        public static String ADMIN_DASHBOARD_CHG_CUSTOMERS_EDIT = HOST_URL + "Dashboards/Admin/AdminEditCustomer.aspx";
        public static String ADMIN_DASHBOARD_CHG_LOCATIONS = HOST_URL + "Dashboards/Admin/AdminLocations.aspx";
        public static String ADMIN_DASHBOARD_CHG_LOCATIONS_EDIT = HOST_URL + "Dashboards/Admin/AdminEditLocation.aspx";
        public static String ADMIN_DASHBOARD_CHG_LOCATIONS_DELETE = HOST_URL + "Dashboards/Admin/AdminDeleteLocation.aspx";
        public static string ADMIN_DASHBOARD_CHG_POINTS_EDIT = HOST_URL + "Dashboards/Admin/AdminEditPoint.aspx";
        public static String ADMIN_DASHBOARD_CHG_TRANSACTIONS_TODAY = HOST_URL + "Dashboards/Admin/AdminTransactionsToday.aspx";
        public static String ADMIN_DASHBOARD_CHG_TRANSACTIONS_THIS_MONTH = HOST_URL + "Dashboards/Admin/AdminTransactionsThisMonth.aspx";
        public static String ADMIN_DASHBOARD_CHG_TRANSACTIONS_LAST_MONTH = HOST_URL + "Dashboards/Admin/AdminTransactionsLastMonth.aspx";
        public static String ADMIN_DASHBOARD_CHG_TRANSACTIONS_PRIOR_MONTH = HOST_URL + "Dashboards/Admin/AdminTransactionsPriorMonth.aspx";
        public static String ADMIN_DASHBOARD_CHG_TRANSACTIONS_ALL = HOST_URL + "Dashboards/Admin/AdminTransactionsAll.aspx";
        public static string ADMIN_DASHBOARD_CREATE_NETWORK = HOST_URL + "Dashboards/Admin/AdminCreateNetwork.aspx";
        public static string ADMIN_DASHBOARD_CREATE_POINT = HOST_URL + "Dashboards/Admin/AdminCreatePoint.aspx";
        
        public static string ADMIN_DASHBOARD_CHG_POINT_OWNERS_EDIT = HOST_URL + "Dashboards/Admin/AdminEditPointOwner.aspx";
        public static string ADMIN_DASHBOARD_CHG_NETWORK_OWNERS_EDIT = HOST_URL + "Dashboards/Admin/AdminEditNetworkOwner.aspx";
        public static string VIEW_PROFILE_URL_ADMIN = HOST_URL + "/Dashboards/Admin/AdminProfile.aspx";
        public static string EDIT_PROFILE_URL_ADMIN = HOST_URL + "/Dashboards/Admin/AdminEditProfile.aspx";

        //Customer Dashboard Links
        public static string VIEW_PROFILE_URL_CUSTOMER = HOST_URL + "Dashboards/Customer/CustomerProfile.aspx";
        public static string EDIT_PROFILE_URL_CUSTOMER = HOST_URL + "Dashboards/Customer/EditCustomer.aspx";

        //Network Owner Dashboard Links
        public static string VIEW_PROFILE_URL_NETWORK_OWNER = HOST_URL + "Dashboards/NetworkOwner/NetworkOwnerProfile.aspx";
        public static string EDIT_PROFILE_URL_NETWORK_OWNER = HOST_URL + "Dashboards/NetworkOwner/NetworkOwnerEditProfile.aspx";

        //Point Owner Dashboard Links
        public static string VIEW_PROFILE_URL_POINT_OWNER = HOST_URL + "Dashboards/PointOwner/PointOwnerProfile.aspx";
        public static string EDIT_PROFILE_URL_POINT_OWNER = HOST_URL + "Dashboards/PointOwner/PointOwnerEditProfile.aspx";

        //Staff Links
        public static string STAFF_DASHBOARD_CREATE_CUSTOMER = HOST_URL + "Dashboards/Staff/StaffCreateCustomer.aspx";
        public static string STAFF_DASHBOARD_CHG_CUSTOMERS = HOST_URL + "Dashboards/Staff/StaffCustomers.aspx";
        public static string STAFF_DASHBOARD_EDIT_CUSTOMER = HOST_URL + "Dashboards/Staff/StaffEditCustomer.aspx";
        public static string VIEW_PROFILE_URL_STAFF = HOST_URL + "Dashboards/Staff/StaffProfile.aspx";
        public static string EDIT_PROFILE_URL_STAFF = HOST_URL + "Dashboards/Staff/StaffEditProfile.aspx";
        public static string STAFF_DASHBOARD_EDIT_CARD_REQUEST = HOST_URL + "Dashboards/Staff/StaffEditCardRequest.aspx";
        public static string STAFF_DASHBOARD_CHG_CARD_REQUESTS = HOST_URL + "Dashboards/Staff/StaffCardRequests.aspx";

        //Accountant Links
        public static string VIEW_PROFILE_URL_ACCOUNTANT = HOST_URL + "Dashboards/Accountant/AccountantProfile.aspx";
        public static string EDIT_PROFILE_URL_ACCOUNTANT = HOST_URL + "Dashboards/Accountant/AccountantEditProfile.aspx";


        //Identity Server Links
        public static string IS_PORT = AppFunction.ReadSetting("IdentityServerPort");
        public static string DS_PORT = AppFunction.ReadSetting("DeviceServerPort");

        public static string HOST_URL_IDENTITY_SERVER = string.Format("http://{0}:{1}/", HttpContext.Current.Request.Url.Host, IS_PORT);
        public static string HOST_URL_DEVICE_SERVER = string.Format("http://{0}:{1}/", HttpContext.Current.Request.Url.Host, DS_PORT);

        public static string CHECK_LOGIN_POST = HOST_URL_IDENTITY_SERVER + "LoginController.asmx/CheckLoginPOST";
        public static string CHECK_LOGIN_POST_JSON = HOST_URL_IDENTITY_SERVER + "LoginController.asmx/CheckLoginPOSTJSON";
        public static string CHECK_LOGOUT_POST_JSON = HOST_URL_IDENTITY_SERVER + "LoginController.asmx/LogOut";
        public static string RESET_PASSWORD_JSON = HOST_URL_IDENTITY_SERVER + "DatabaseHandler.asmx/ResetPassword";
        public static string ADD_CUSTOMER = HOST_URL_IDENTITY_SERVER + "UserController.asmx/AddUserJSON";
        public static string UPDATE_CUSTOMER = HOST_URL_IDENTITY_SERVER + "UserController.asmx/UpdateCustomerJSON";
        public static string UPDATE_CUSTOMER_ALL_FIELDS = HOST_URL_IDENTITY_SERVER + "UserController.asmx/UpdateCustomerAllFieldsJSON";
        public static string UPDATE_USER_IMAGE = HOST_URL_IDENTITY_SERVER + "UserController.asmx/UpdateUserImageJSON";
        public static string ADD_USER = HOST_URL_IDENTITY_SERVER + "UserController.asmx/AddUserJSON";
        public static string CHECK_USERNAME = HOST_URL_IDENTITY_SERVER + "UserController.asmx/CheckUserNameJSON";
        public static string CHECK_EMAIL = HOST_URL_IDENTITY_SERVER + "UserController.asmx/DoesEmailExist";
        public static string GET_CUSTOMER = HOST_URL_IDENTITY_SERVER + "PortalService.asmx/GetUserDetails";
        public static string VALIDATE_NFC = HOST_URL_IDENTITY_SERVER + "PortalService.asmx/DoesNFCExist";
        public static string VALIDATE_USERNAME = HOST_URL_IDENTITY_SERVER + "PortalService.asmx/DoesUsernameExist";
        public static string VALIDATE_EMAIL = HOST_URL_IDENTITY_SERVER + "PortalService.asmx/DoesEmailExist";
        public static string VALIDATE_EMAIL_DUPLICATE = HOST_URL_IDENTITY_SERVER + "PortalService.asmx/IsDuplicateEmail";
        public static string ACTIVATE_USER = HOST_URL_IDENTITY_SERVER + "UserController.asmx/ActivateUser";
        public static string RESEND_ACTIVATION_EMAIL = HOST_URL_IDENTITY_SERVER + "UserController.asmx/ResendActivationEmail";
        public static string GETGREENHOUSELOCATIONS = HOST_URL_DEVICE_SERVER + "GreenhouseController.asmx/GetGreenhouseLocationsByUserID";

        //IS Constants
        public const string CREDENTIALS = "CREDENTIALS";
        public const string VALID = "VALID";
        public const string INVALID = "INVALID";
        public const string WEB = "WEB";

        //Transaction Server Links
        public static String TRS_PORT = AppFunction.ReadSetting("TransactionServerPort");
        public static String HOST_URL_TRANSACTION_SERVER = string.Format("http://{0}:{1}/", HttpContext.Current.Request.Url.Host, TRS_PORT);
        public static string RELOAD_URL = HOST_URL_TRANSACTION_SERVER + "ReloadHandler.asmx/ReloadByCash";
        public static string SMS_URL = HOST_URL_TRANSACTION_SERVER + "SMSHandler.asmx/SendSMS";

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
        #endregion

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