/*
* ***----****----****----****----****
 Author: Sidath Gajanayaka
 © 2015-2017 - SG Creations
 All Rights Reserved. Licensed for use within chargeNET Pvt. Ltd.
 scgcreations@gmail.com
* ***----****----****----****----****
*/

namespace AiGrow.Classes
{
    public class Messages
    {
        public static string fieldsRequired = "One or more of the required fields are blank. Please retry!";
        public static string successfulRegistration = "Registration successful! An email has been sent to <email>. Please click on the link sent to activate your account.";
        public static string userExistsCustomer = "The username you entered is already in our database. Please enter a different username. If you own the entered username please contact the System Administrator or go to \"Forgot Password\" in the Login section to reset the password.";
        public static string invalidUsernameOrPassword = "Invalid username or password. Cannot login. Please retry.";
        public static string userExists = "Username is already in the system. Please enter a different username.";
        public static string userNameOrEmailExists = "Username and / or email is already in the system. Please enter a different username / email.";
        public static string invalidRequest = "Invalid Request.";
        public static string logoutSuccess = "You have logged out successfully.";
        public static string deleteConfirmation = "Are you sure you want to delete the ";
        public static string actionCannotBeUndone = "This action cannot be undone!";
        public static string chargePointDeletedSuccessfully = "Charge Point deleted successfully!";
        public static string chargePointDeletionFailed = "Charge Point deletion failed. Please contact the System Administrator!";
        public static string chargeNetworkDeletionFailed = "Charge Network deletion failed. Please contact the System Administrator!";
        public static string chargeCustomerDeletedSuccessfully = "Charge Customer deleted successfully!";
        public static string chargeCustomerUpdatedSuccessfully = "Charge Customer updated successfully!";
        public static string chargeNetworkOwnerDeletionFailed = "Charge Network Owner deletion failed. Please contact the System Administrator!";
        public static string chargeNetworkOwnerDeletedSuccessfully = "Charge Network Owner deleted successfully!";
        public static string chargePointOwnerDeletionFailed = "Charge Point Owner deletion failed. Please contact the System Administrator!";
        public static string chargeCustomerDeletionFailed = "Charge Customer deleton failed. Please contact the System Administrator.";
        public static string chargePointOwnerDeletedSuccessfully = "Charge Point Owner deleted successfully!";
        public static string chargeNetworkUpdatedSuccessfully = "Charge Network updated successfully!";
        public static string chargeNetworkDeletedSuccessfully = "Charge Network deleted successfully!";
        public static string successfulLocationCreation = "Charge Location created successfully!";
        public static string locationEditedSuccessfully = "Charge Location edited successfully!";
        public static string locationExists = "Location Name is already in our database. Please choose another name!";
        public static string invalidValues = "One or more of the values entered are invalid. Please retry!";
        public static string showingTransactionsFrom = "Showing transactions from";
        public static string showingReloadsFrom = "Showing reloads from";
        public static string chargeNetworkNameExists = "There is already a network by the name you have entered. Please enter a different name!";
        public static string chargeNetworkCreatedSuccessfully = "Charge Network created successfully!";
        public static string chargeLocationCreatedSuccessfully = "Charge Location created successfully!";
        public static string passwordsDoNotMatch = "The passwords you entered do not match. Please re-enter.";
        public static string passwordChangedSuccessfully = "Your password was changed successfully. Login from here!";
        public static string profileUpdatedSuccessfully = "Your profile was updated successfully.";
        public static string usernameNotInDatabase = "The username you entered is not in our databases. Please retry.";
        public static string pleaseCheckYourEmail = "Please check your email.";
        public static string aMessageWasSentTo = "An email was sent to: ";
        public static string errorUpdatingCustomer = "There was an error in updating customer details. Please contact the System Administrator.";
        public static string errorUpdatingPoint = "There was an error in updating charge station details. Please contact the System Administrator.";
        public static string errorUpdatingPointOwner = "There was an error in updating station owner details. Please contact the System Administrator.";
        public static string errorUpdatingNetworkOwner = "There was an error in updating network owner details. Please contact the System Administrator.";
        public static string chargePointOwnerUpdatedSuccessfully = "Charge Point Owner updated successfully!";
        public static string chargeNetworkOwnerUpdatedSuccessfully = "Charge Network Owner updated successfully!";
        public static string stationUpdatedSuccessfully = "Charge Point updated successfully!";
        public static string stationExists = "Point Name is already in our database. Please choose another name!";
        public static string chargePointUpdatedSuccessfully = "Charge Point updated successfully!";
        public static string chargePointCreatedSuccessfully = "Charge Point created successfully!";
        public static string chargePointExists = "Charge Point reference is already in our database. Please choose another reference!";
        public static string chargeLocationDeletionFailed = "Charge Location deleton failed. Please contact the System Administrator.";
        public static string chargeLocationDeletedSuccessfully = "Charge Location successfully deleted.";
        public static string undefinedError = "An undefined error occurred. Please contact the System Administrator.";
        public static string selectACustomer = "Please select a customer to reload.";
        public static string yourBalanceIs = " Your new balance is: Rs. ";
        public static string customerBalanceIs = " Customer's new balance is: Rs. ";
        public static string thankYou = "Thank you for using chargeNET.";
        public static string valueSelected = "Value: <NFC> selected!";
        public static string valueNotAvailable = "Value: <NFC> is not available!";
        public static string enterValidValue = "One or more of the values you have entered is / are invalid. Please re-check!";
        public static string welcomeToChargeNET = "Welcome to chargeNET";
        public static string welcomeSMS = "Thank you for signing up with chargeNET. Your username is: <username> which you may use to login to your portal at <portal_url>. Thank you.";
        public static string imageUploadError = "There is an error with the image you uploaded. It should be less than ";
        public static string userActivatedSuccessfully = "The user was activated successfully.";
        public static string noSuchUserFoundOrPinIsIncorrect = "No such user found or PIN provided is incorrect. Please re-check!";
        public static string activateYourAccount = "Please activate your account.";
        public static string resendActivationEmail = "Click <here> to resend activation email.";
        public static string imageSizeExceeded = "The image is more than the allowed size of 2 MB. Please select a different image.";
        public static string errorRetrievingBalance = "There was an error in retrieving your balance. Please contact the chargeNET Support Team.";
        public static string requestAlreadyAdded = "We have already received a card request from you. If you wish to inquire about it, please contact us.";
        public static string requestAdded = "We have received your card request. The card will be posted to the address suplied. Thank you.";
        public static string chargeCardRequestUpdatedSuccessfully = "Charge card request updated successfully.";
        public static string removeExistingChargePoints = "Cannot delete network. Please remove existing charge points under the network.";
    }
}