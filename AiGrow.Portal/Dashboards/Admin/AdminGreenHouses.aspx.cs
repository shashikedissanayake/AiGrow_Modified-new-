using AiGrow.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AiGrow.Portal.Dashboards.Admin
{
    public partial class AdminGreenHouses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.FindControl("errorDiv").Visible = false;
            Master.FindControl("successDiv").Visible = false;
            if (!IsPostBack)
            {
                gridGetDataSet();
                gvNetworks.DataBind();
                selectGreenHouses_DataBinding();
            }
        }

        private void selectGreenHouses_DataBinding()
        {
            DataTable dt_owner_user_names = new BL_Greenhouse().selectAllGreenhouses();
            //Map the list to the username list box.
            selectGreenHouses.DataSource = dt_owner_user_names;
            selectGreenHouses.DataValueField = "greenhouse_id";
            selectGreenHouses.DataTextField = "greenhouse_unique_id";
            selectGreenHouses.DataBind();
           
        }

        protected void gvNetworks_DataBinding(object sender, EventArgs e)
        {
            gridGetDataSet();
        }

        private void gridGetDataSet()
        {
            gvNetworks.DataSource = new BL_GreenHouses().select();

        }

        protected void addNewgreenhouse(object sender, EventArgs e)
        {

        }
    }
}