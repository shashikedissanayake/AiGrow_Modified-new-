using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace AiGrow.Portal
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HttpContext.Current.Request.QueryString["username"] != null)
                {
                    txt_username.Text = string.Format("{0}: <b>{1}</b>", Constants.Username, Encryption.Base64Decode(HttpContext.Current.Request.QueryString["username"].ToString()));
                }

            }
            try
            {
                SmtpClient client = new SmtpClient();

                //Mailer.sendMail(Mailer.setMailClientSettings());
            }
            catch (SmtpException ex_smtp)
            {
                Response.Write(ex_smtp.StackTrace);
                Response.Write(ex_smtp.Message.ToString());
            }
        }

        protected void submitButtonClick(Object sender, EventArgs e)
        {
            string username_enc = HttpContext.Current.Request.QueryString["username"];

            string userID = Encryption.Base64Decode(HttpContext.Current.Request.QueryString["userID"]);

            string username_dec = Encryption.Base64Decode(username_enc);

            string email_dec = Encryption.Base64Decode(HttpContext.Current.Request.QueryString["token_email"]);

            string email_enc = HttpContext.Current.Request.QueryString["token_email"];

            string password = pass.Text;
            string retypePassword = passConfirm.Text;


            if (Page.IsValid)
            {
                if ((password == retypePassword) && email_dec != null && username_dec != null)
                {
                    RequestHandler post = new RequestHandler();
                    post.Url = Constants.RESET_PASSWORD_JSON;
                    post.PostItems.Add("UserName", username_dec);
                    post.PostItems.Add("Password", password);
                    post.PostItems.Add("UserID", userID);
                    post.PostItems.Add("token", Encryption.createSHA1(username_dec + password + userID));

                    post.Type = RequestHandler.PostTypeEnum.Post;
                    string result = post.Post();

                    string jsonString = new Regex(@"\{(.*?)\}").Matches(result)[0].ToString();

                    JSONReturn resetPassword = new JavaScriptSerializer().Deserialize<JSONReturn>(jsonString);

                    if (resetPassword.errorText == null)
                    {
                        Response.Redirect(string.Format("{0}?message={1}&token={2}&username={3}", Constants.LOGIN_URL, Classes.Messages.passwordChangedSuccessfully, Encryption.createSHA1(Classes.Messages.passwordChangedSuccessfully), username_enc));
                    }
                    else
                    {
                        Response.Redirect(string.Format("{0}?error={1}&token={2}&token_email={3}&email={4}&username={5}&userID={6}", Constants.RESET_PASSWORD, resetPassword.errorText, Encryption.createSHA1(resetPassword.errorText), email_enc, email_dec, username_enc, Encryption.Base64Encode(userID)));
                    }
                }
                else
                {
                    Response.Redirect(string.Format("{0}?error={1}&token={2}&token_email={3}&email={4}&username={5}&userID={6}", Constants.RESET_PASSWORD, Classes.Messages.passwordsDoNotMatch, Encryption.createSHA1(Classes.Messages.passwordsDoNotMatch), email_enc, email_dec, username_enc, Encryption.Base64Encode(userID)));
                }
            }
            else
            {
                Response.Redirect(string.Format("{0}?error={1}&token={2}&token_email={3}&email={4}&username={5}&userID={6}", Constants.RESET_PASSWORD, Classes.Messages.invalidRequest, Encryption.createSHA1(Classes.Messages.invalidRequest), email_enc, email_dec, username_enc, Encryption.Base64Encode(userID)));

            }
        }

    }
}