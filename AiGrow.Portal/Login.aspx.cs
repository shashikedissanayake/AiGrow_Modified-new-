using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AiGrow.Business;
using AiGrow.Classes;
using System.Data;
using System.Net;

namespace AiGrow.Portal
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signinClick(object sender, EventArgs e)
        {


            if (Page.IsValid)
            {
                try
                {

                    string user_name = userName.Text.Trim();
                    string pass_word = password.Text.Trim();

                    LoginResponse login = MyUser.validateUserIS(user_name, pass_word);

                    if (login.credentials == Constants.VALID && login.success == true)
                    {
                        using (DataTable dt = new BL_User().selectByUserName(new Model.ML_User()
                        {
                            username = user_name
                        }))
                        {
                            string type = dt.Rows[0]["role_name"].ToString();
                            string userID = dt.Rows[0]["id_user"].ToString();
                            string loginID = login.loginID;

                            SessionHandler.initiateLoginSession(user_name, type, login.token, userID, loginID);

                            switch (type.Trim())
                            {
                                case Constants.AIGROW_ADMIN:
                                    Response.Redirect(Constants.HOME_PATH_DASHBOARDS_ADMIN + "Index.aspx", false);
                                    break;
                                case Constants.CHG_NETWORK:
                                    Response.Redirect(Constants.HOME_PATH_DASHBOARDS_NETWORK_OWNER + "Index.aspx", false);
                                    break;
                                case Constants.AIGROW_CUSTOMER:
                                    Response.Redirect(Constants.HOME_PATH_DASHBOARDS_CUSTOMER + "Index.aspx", false);
                                    break;
                                case Constants.CHG_OWNER:
                                    Response.Redirect(Constants.HOME_PATH_DASHBOARDS_CHARGE_POINT_OWNER + "Index.aspx", false);
                                    break;
                                case Constants.CHG_STAFF:
                                    Response.Redirect(Constants.HOME_PATH_DASHBOARDS_STAFF + "Index.aspx", false);
                                    break;
                                case Constants.CHG_ACCOUNTANT:
                                    Response.Redirect(Constants.HOME_PATH_DASHBOARDS_ACCOUNTANT + "Index.aspx", false);
                                    break;
                                default:
                                    Response.Redirect(string.Format("{0}?error={1}&token={2}", Constants.LOGIN_URL, Messages.undefinedError, Encryption.createSHA1(Messages.undefinedError)), false);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        if (login.errorCode == Constants.EC_UserNotActive)
                        {
                            string message = login.errorMessage + " " + Messages.activateYourAccount + " " + Messages.resendActivationEmail.Replace("<here>", "<a href=\"../ResendActivationEmail.aspx?username=" + userName.Text.Trim() + "\">here</a>");

                            string message_enc = WebUtility.UrlEncode(Encryption.Base64Encode(message));
                            Response.Redirect(string.Format("{0}?message_enc={1}&token={2}", Constants.LOGIN_URL, message_enc, Encryption.createSHA1(message_enc)), false);
                        }
                        else
                        {
                            Response.Redirect(string.Format("{0}?error={1}&token={2}", Constants.LOGIN_URL, Messages.invalidUsernameOrPassword, Encryption.createSHA1(Messages.invalidUsernameOrPassword)), false);
                        }
                    }
                }
                catch(Exception error)
                {
                    ApplicationUtilities.writeMsg(error.StackTrace);
                    ApplicationUtilities.writeMsg(error.Message);

                    Response.Redirect(string.Format("{0}?error={1}&token={2}", Constants.LOGIN_URL, Messages.undefinedError, Encryption.createSHA1(Messages.undefinedError)), false);
                }
            }
            else
            {
                userName.Focus();
            }



        }
    }
}