using AiGrow.Business;
using AiGrow.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AiGrow.Portal
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
            }
        }

        protected void submitButtonClick(Object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string userID = MyUser.getUserIDFromUsername(username);
            string email = MyUser.getEmailFromUsername(username);

            if (Page.IsValid && username != null)
            {
                if (Page.IsValid && email != null)
                {
                    string resetLink = string.Format("{0}Dashboards/ResetPassword.aspx?username={1}&token_email={2}&email={3}&userID={4}", Constants.HOST_URL, Encryption.Base64Encode(username), Encryption.Base64Encode(email), email, Encryption.Base64Encode(userID));

                    string emailReset = new BL_Configurations().getConfigValue(Constants.resetPasswordEmailText).Rows[0][0].ToString();

                    Mailer passwordResetMail = new Mailer(Constants.INFO_CHARGENET_EMAIL, Constants.INFO_CHARGENET_PASSWORD, true);

                    passwordResetMail.sendEmail(Constants.INFO_CHARGENET_EMAIL_FROM, email, "Password Reset Request: chargeNET", emailReset.Replace("{0}", username).Replace("{1}", resetLink));

                    string message = string.Format("{0}{1}. {2}", Messages.aMessageWasSentTo, email, Messages.pleaseCheckYourEmail);

                    Response.Redirect(string.Format("{0}?message={1}&token={2}&username={3}", Constants.LOGIN_URL, message, Encryption.createSHA1(message), Encryption.Base64Encode(username)));
                }
                else
                {
                    lblError.Text = "";
                    lblError.Text = Messages.usernameNotInDatabase;
                    txtUsername.Text = "";
                    txtUsername.Focus();
                    //return;
                }
            }
            else
            {
                //Response.Redirect(string.Format("{0}?error={1}&token={2}&token_email={3}&email={4}&username={5}", Constants.RESET_PASSWORD, Classes.Messages.invalidRequest, Encryption.createSHA1(Classes.Messages.invalidRequest), email_enc, email_dec, username_enc));

            }

        }
    }
}