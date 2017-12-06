using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AiGrow.DeviceServer
{

    public static class UniversalProperties
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
        public const string start_url = "start_url";
        public const string stop_url = "stop_url";
        #endregion

        public const string SriLanka = "Sri Lanka";
        public static string MySQLDateFormat = "yyyy-MM-dd HH:mm:ss";

        public const string passwordLengthInvalid = "The password length does not match the requirements.";
        public const string locationInsertedSuccessfully = "Location inserted successfully.";
        public const string locationDeletedSuccessfully = "Location deleted successfully.";
        public const string invalidRequest = "Invalid request.";
        public const string invalidEmail = "You have entered an invalid email. Please re-check!";
        public const string invalidMobile = "You have entered an invalid mobile no. Please re-check!";
        public static string userExists = "Username is already in the system. Please enter a different username.";
        public static string noSuchUserFound = "The specified username is not available in the system. Please re-check!";
        public static string userAddedSuccesfully = "The user was added successfully.";
        public static string locationUpdateFailed = "Error in updating location";
        public static string locationUpdatedSuccesfully = "The location was updated successfully";
        public static string ratingUpdated = "Rating updated successfully.";
        public static string favouriteUpdated = "User favourite value updated successfully.";
        public static string error = "ERROR";
        public static string userInsertionFailed = "There was an error in adding the user. Please contact the System Administrator.";
        public static string requiredFieldsMissing = "One or more of the required fields are missing. Please re-check.";
        public static string reloadAddedSuccessfully = "Your reload of Rs. <amount> was added successfully.";
        public static string messageSentSuccessfully = "SMS sent successfully.";

        public static string invalidToken = "Invalid token.";
        public static string invalidChargePoint = "Invalid charge point supplied.";
        public static string loginModeApp = "APP";

        public static string credentialsValid = "VALID";
        public static string credentialsInvalid = "INVALID. PLEASE RE-CHECK!";
        public static string credentials = "CREDENTIALS";

        //User Constants
        public const String AIGROW_ADMIN = "AIGROW_ADMIN";
        public const String AIGROW_NETWORK = "AIGROW_NETWORK";
        public const String AIGROW_OWNER = "AIGROW_OWNER";
        public const String AIGROW_CUSTOMER = "AIGROW_CUSTOMER";
        public const String ACTIVE_USER = "ACTIVE_USER";
        public const String INACTIVE_USER = "INACTIVE_USER";
        public const String ONLINE = "ONLINE";
        public const String DUMMY_NFC_REF = "DUMMY_NFC_REF";

        public const string Username = "username";
        public const string Password = "password";
        public const string Mobile = "mobile";
        public const string Email = "email";

        //IS Constants
        public const string CREDENTIALS = "CREDENTIALS";
        public const string VALID = "VALID";
        public const string INVALID = "INVALID";
        public const string PASSWORD_UPDATE_STATUS = "PASSWORD_UPDATE_STATUS";
        public const string TRUE = "TRUE";
        public const string VALIDATE_LOGIN = "LOGIN_VALIDATE_REQUEST";
        public const string LOGIN_TOKEN = "LOGIN_TOKEN";
        public const string LOGIN_ID = "LOGIN_ID";
        public const string TOKEN_VALIDATION = "TOKEN_VALIDATION";
        public const string userPassInvalid = "The username and / or password is invalid. Please recheck!";

        //TS Constants
        public const string STARTED = "STARTED";
        public const string STOPPED = "STOPPED";
        public const string HEAD_OFFICE = "HEAD_OFFICE";
        public const string AVAILABILITY_STATUS_AVAILABLE = "AVAILABLE";
        public const string AVAILABILITY_STATUS_UNAVAILABLE = "UNAVAILABLE";
        public const string AVAILABILITY_STATUS_OCCUPIED = "OCCUPIED";
        //public const string AVAILABILITY_STATUS_BLOCKED = "BLOCKED";
        public const string USER_STATUS_ACTIVE = "ACTIVE_USER";
        public const string USER_STATUS_BLOCKED = "BLOCKED_USER";
        public const string ERROR_TEXT_INSUFFICIENT_BALANCE = "Error. Insufficient balance. Charging cannot start.";
        public const string ERROR_TEXT_USER_NOT_IN_NETWORK = "Error. The user is not in the network of the charger.";
        public const string ERROR_TEXT_NOT_ALLOWED_TO_OTHERS = "Error. The charger does not allow non members of the network to charge.";
        public const string ERROR_TEXT_USER_OR_CHARGE_POINT_NOT_ACTIVE = "Error. The charge point or user is not in active status.";
        public const string ERROR_TEXT_CHARGE_NETWORK_IS_PRIVATE = "Error. The network of the charge point is a private network.";
        public const string unknownError = "Undefined error occurred. Please contact the administrator.";
        public const string invalidMqttRequest = "Invalid Request";
        public const string bayNotRegsitered = "Bay registration error.";
        public const string lineNotRegsitered = "Line registration error.";
        public const string rackNotRegsitered = "Rack registration error.";
        public const string messageNotSent = "The SMS was not sent.";
        public const string invalidTransactionID = "The supplied transaction ID is invalid or malformed.";
        public const string duplicateStopRequest = "Duplicate stop request for a stopped transaction ID.";
        public const string duplicateTransactionID = "Duplicate transaction ID generated.";
        public const string userNotActive = "User is not in active state.";

        #region Charge Types

        public const string CHARGE = "CHARGE";
        public const string CASH = "CASH";
        public const string TOPUP = "TOPUP";

        #endregion

        #region Data Table Constants

        public const string MQTT_topic = "/ai_test";

        public const string data = "dataEntry";
        public const string greenhouse = "registerGreenhouse";
        public const string greenhouseDevice = "registerGreenhouseDevice";
        public const string bay = "registerBay";
        public const string bayDevice = "registerBayDevice";
        public const string bayLine = "registerBayLine";
        public const string bayLineDevice = "registerBayLineDevice";
        public const string bayRack = "registerBayRack";
        public const string bayRackDevice = "registerBayRackDevice";

        public static int greenhouse_device = 1;
        public static int bay_device = 2;
        public static int bay_line_device = 3;
        public static int bay_rack_device = 4;
        public static int bay_rack_level_device_data = 5;
        public static int bay_rack_level_line_device_data = 6;

        public static string UNKNOWN_COMPONENT = "Unknown Component.";

        public static string DATA_ENTERED_SUCCESSFULLY = "Data Entered succesfully";
        public static string GREENHOUSE_REGISTERED_SUCCESSFULLY = "Greenhouse Registered succesfully";
        public static string BAY_REGISTERED_SUCCESSFULLY = "Bay Registered succesfully";
        public static string LINE_REGISTERED_SUCCESSFULLY = "Line Registered succesfully";
        public static string RACK_REGISTERED_SUCCESSFULLY = "Rack Registered succesfully";
        public static string DEVICE_REGISTERED_SUCCESSFULLY = "Device Registered succesfully";

        public static string DUPLICATE_BAY = "Bay Already Exists";
        public static string DUPLICATE_BAY_DEVICE = "Bay Device Already Exists";
        public static string DUPLICATE_BAY_RACK_DEVICE = "Bay Rack Device Already Exists";
        public static string DUPLICATE_GREENHOUSE_DEVICE = "Greenhouse Device Already Exists";
        public static string DUPLICATE_BAY_LINE = "Bay Line Already Exists";
        public static string DUPLICATE_BAY_RACK = "Bay Rack Already Exists";
        public static string DUPLICATE_BAY_LINE_DEVICE = "Bay Line Device Already Exists";
        
        #endregion


        #region Charger Constants

        public static double doubleRate = 4.5;
        public static string LEVEL2 = "L2";
        public static string LEVEL3 = "L3";
        public static string FAST = "FAST";

        #endregion

        #region Requests and Responses Form
        public const string GOOGLE_FORM_REQUESTS_AND_RESPONSES = "https://docs.google.com/forms/d/e/1FAIpQLSce55xBihiSJuL6AMmSpMtuJq5iBvicpzqhyfvamWNfFeon2Q/formResponse";
        public const string request_Key_RequestsForm = "entry.239401219";
        public const string USP_Key_RequestsForm = "usp";
        public const string USP_Value_RequestsForm = "pp_url";
        public const string userID_Key_RequestsForm = "entry.834595345";
        public const string chargePointID_Key_RequestsForm = "entry.21961045";
        public const string transactionID_Key_RequestsForm = "entry.838917484";
        public const string time_Key_RequestsForm = "entry.696364263";
        public const string energy_Key_RequestsForm = "entry.1976656281";
        #endregion

        #region Error Form
        public const string GOOGLE_FORM_ERRORS = "https://docs.google.com/forms/d/e/1FAIpQLScwrB-ZMPEdR9wxlhdmuPY_fLkXEZMhoiXH9i7AXg4nb8gjdQ/formResponse";
        public const string errorText_Key_ErrorForm = "entry.1405393853";
        #endregion

        #region Charger Reset Requests Form
        public const string GOOGLE_FORM_CHARGER_RESET_REQUESTS = "https://docs.google.com/forms/d/e/1FAIpQLSfQYW-E5SdY_6l9iFhdXVIRxuZkmjJW4fnSLIZVbo5tcTvtbw/formResponse";
        #endregion

        #region Modes
        public const string START_TRANSACTION = "START_TRANSACTION";
        public const string STOP_TRANSACTION = "STOP_TRANSACTION";
        public const string STOP_TRANSACTION_TEST = "STOP_TRANSACTION_TEST";
        public const string CHARGER_RESET = "CHARGER_RESET";

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
        public const int EC_LocationUpdateFailed = 23;
        public const int EC_UnknownComponent = 24;
        public const int EC_RegistrationError = 25;
        public const int EC_InvalidMqttRequest = 26;

        #endregion

        #region SMS API Constants

        public const string destination_Key_SMS = "destination";
        public const string SMS_GATEWAY = "SMS_GATEWAY";
        public const string q_Key_SMS = "q";
        public const string message_Key_SMS = "message";
        public const string DIALOG_SMS_API_URL = "https://cpsolutions.dialog.lk/index.php/cbs/sms/send";
        public const string STOP_SMS = "Dear <username>, your EV has finished charging. Units: <units> kWh, Time: <time> Mins, Cost: Rs. <cost>, Balance: Rs. <balance>. Thank you!";
        public const string STOP_SMS_ERROR = "Dear <username>, your EV has finished charging. Date: <timestamp>, Units: <units> kWh, Time: <time> Mins, Cost: Rs. <cost>, Balance: Rs. <balance>. Thank you!";
        public static string yourBalanceIs = " Your new balance is: Rs. ";
        public static string customerBalanceIs = " Customer's new balance is: Rs. ";
        public static string thankYou = "Thank you for using chargeNET.";
        #endregion

        public static string STOP_TRANSACTION_URL_LOCAL = "http://localhost:13000/ChargerHandler.asmx/StopTransactionTest";
        public static string STOP_TRANSACTION_URL = "http://api.chargenet.lk:13000/ChargerHandler.asmx/StopTransactionTest";

        #region Promotion Manager Links

        public static string ADD_PROMOTION = "PromotionService.asmx/AddPromotion";

        public const string start = "start";
        public const string end = "end";
        public const string value = "value";
        public const string charging = "charging";
        public const string broadcast = "broadcast";

        #endregion
    }


}
