using AiGrow.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AiGrow.Portal
{
    public partial class signUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errorDiv.Visible = false;

            //getCountryList();
            foreach (String my_country in getCountryList())
            {
                lst_countries.Items.Add(my_country);
            }
           
        }

        public static List<String> getCountryList()
        {
            List<String> country = new List<string>(new AiGrow.Business.BL_Configurations().getConfigValue(Constants.countryList).Rows[0][0].ToString().Split(new char[] { ';' }));
            country.Sort();
            return country;
        }

       

        protected void submitButtonClick(Object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    var checkUserName = AppFunction.doesUserNameExist(id_txt_username.Text.Trim());

                    var checkEmail = AppFunction.doesEmailExist(id_txt_email.Text.Trim(), Encryption.createSHA1(id_txt_email.Text.Trim()));

                    BaseResponse serverResponse = new JavaScriptSerializer().Deserialize<BaseResponse>(checkUserName);
                    BaseResponse serverResponseEmail = new JavaScriptSerializer().Deserialize<BaseResponse>(checkEmail);

                    if (serverResponse.message == "True" || serverResponseEmail.message == "True")
                    {
                        errorDiv.Visible = true;
                        errorMessage.InnerHtml = Messages.userNameOrEmailExists;
                        return;
                    }
                    else
                    {
                        errorDiv.Visible = false;
                        errorMessage.InnerHtml = string.Empty;
                    }

                    RequestHandler post = new RequestHandler();
                    post.Url = Constants.ADD_CUSTOMER;
                    post.PostItems.Add("userName", id_txt_username.Text.Trim());
                    post.PostItems.Add("password", id_txt_password.Text.Trim());
                    post.PostItems.Add("token", Encryption.createSHA1(id_txt_username.Text.Trim() + id_txt_password.Text.Trim()));
                    post.PostItems.Add("gender", cbo_gender.Text.Trim());
                    post.PostItems.Add("title", cbo_title.Text.Trim());
                    post.PostItems.Add("mobile", id_txt_mobile.Text.Trim());
                    post.PostItems.Add("email", id_txt_email.Text.Trim());
                    post.PostItems.Add("organizationName", id_txt_org_name.Text.Trim());
                    post.PostItems.Add("telephone", id_txt_telephone.Text.Trim());
                    post.PostItems.Add("lastName", idLastName.Text.Trim());
                    post.PostItems.Add("firstName", idFirstName.Text.Trim());
                    post.PostItems.Add("country", lst_countries.Text.Trim());
                    post.PostItems.Add("address", id_txt_address.Text.Trim());
                    post.PostItems.Add("profilePicURL", null);
                    post.PostItems.Add("role", "AIGROW_CUSTOMER");

                    post.Type = RequestHandler.PostTypeEnum.Post;
                    string result = post.Post();

                    BaseResponse userResponse = new JavaScriptSerializer().Deserialize<BaseResponse>(result);

                    if (userResponse.success == true)
                    {
                       // string userID = new BL_User().getUserIDByUserName(id_txt_username.Text.Trim());

                        Response.Redirect(string.Format("{0}?message={1}&token={2}", Constants.REGISTER_URL, Messages.successfulRegistration.Replace("<email>", id_txt_email.Text.Trim()), Encryption.createSHA1(Messages.successfulRegistration.Replace("<email>", id_txt_email.Text.Trim()))), false);
                    }
                    else
                    {
                        Response.Redirect(string.Format("{0}?error={1}&token={2}", Constants.REGISTER_URL, userResponse.errorMessage, Encryption.createSHA1(userResponse.errorMessage)), false);
                    }
                }
                catch (WebException wex)
                {
                    string pageContent = new StreamReader(wex.Response.GetResponseStream()).ReadToEnd().ToString();
                    Response.Redirect(string.Format("{0}?error={1}&token={2}", Constants.REGISTER_URL, wex.Message, Encryption.createSHA1(wex.Message)), false);
                    return;
                }
            }
            else
            {
                //valSummaryForm.Visible = true;
            }
        }

        private void sendSMS(string userID, string message, string mobileNo)
        {
            RequestHandler post = new RequestHandler();
            post.Url = Constants.SMS_URL;
            post.PostItems.Add("userID", userID);
            post.PostItems.Add("message", message);
            post.PostItems.Add("destination", mobileNo);
            post.PostItems.Add("token", Encryption.createSHA1(userID));
            post.Type = RequestHandler.PostTypeEnum.Post;
            string result = post.Post();
        }

    }
}