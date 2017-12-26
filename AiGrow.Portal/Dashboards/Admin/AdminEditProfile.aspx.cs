using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AiGrow.Business;
using AiGrow.Classes;
using AiGrow.Model;
using System.Web.Script.Serialization;

namespace AiGrow.Portal.Dashboards.Admin
{
    public partial class AdminEditProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);

            Master.FindControl("errorDiv").Visible = false;
            Master.FindControl("successDiv").Visible = false;

            if (!IsPostBack)
            {
                foreach (String my_country in signUp.getCountryList())
                {
                    lst_countries.Items.Add(my_country);
                }
                bindDataToFields();
            }
        }

        private void bindDataToFields()
        {
            ChargeCustomer currentMember = new ChargeCustomer();
            currentMember.getCustomerData();
            id_txt_address.Text = currentMember.Address;
            id_txt_email.Text = currentMember.Email;
            id_txt_mobile.Text = currentMember.Mobile;
            id_txt_org_name.Text = currentMember.OrganizationName;
            id_txt_telephone.Text = currentMember.Telephone;
            cbo_title.Text = currentMember.Title;
            cbo_gender.Text = currentMember.Gender;
            idFirstName.Text = currentMember.FirstName;
            idLastName.Text = currentMember.LastName;
            lst_countries.Text = currentMember.Country;
        }

        public void submitButtonClick(object sender, EventArgs e)
        {
            int userID = SessionHandler.getLoggedInUserID().ToInt();
            try
            {
                RequestHandler post = new RequestHandler();
                post.Url = Constants.UPDATE_CUSTOMER;
                post.PostItems.Add("userID", userID.ToString());
                post.PostItems.Add("password", id_txt_password.Text.Trim().IsNotEmpty() ? id_txt_password.Text.Trim() : null);
                post.PostItems.Add("token", SessionHandler.getToken());
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
                post.PostItems.Add("picURL", null);

                post.Type = RequestHandler.PostTypeEnum.Post;
                string result = post.Post();

                BaseResponse userResponse = new JavaScriptSerializer().Deserialize<BaseResponse>(result);

                if (userResponse.success == true)
                {
                    Response.Redirect(string.Format("{0}?message={1}&token={2}", Constants.EDIT_PROFILE_URL_ADMIN, Messages.profileUpdatedSuccessfully, Encryption.createSHA1(Messages.profileUpdatedSuccessfully)), false);
                    return;
                }
                else
                {
                    string errorMessage = HttpUtility.UrlEncode(userResponse.errorMessage).Replace("+", "%20");

                    Response.Redirect(string.Format("{0}?error={1}&token={2}", Constants.EDIT_PROFILE_URL_ADMIN, errorMessage, Encryption.createSHA1(userResponse.errorMessage)), false);
                    return;
                }
            }
            catch (Exception ex)
            {
                string errorMessage = HttpUtility.UrlEncode(ex.Message).Replace("+", "%20");

                Response.Redirect(string.Format("{0}?error={1}&token={2}", Constants.EDIT_PROFILE_URL_ADMIN, errorMessage, Encryption.createSHA1(ex.Message)), false);
            }
        }
    }
}