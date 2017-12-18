using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AiGrow.Portal.Dashboards.Admin
{
    public partial class AdminEditGreenHouse : System.Web.UI.Page
    {
        protected string greenHouseID = Convert.ToString(HttpContext.Current.Request.QueryString["greenhouseID"]);
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.FindControl("errorDiv").Visible = false;
            Master.FindControl("successDiv").Visible = false;
            if (!IsPostBack)
            {
               
            }
        }

        protected void dataBind() { 
        
            
        }
    }
}