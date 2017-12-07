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
    public partial class AdminDataVisualizer : System.Web.UI.Page
    {
        private string location;
        private string id;

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.FindControl("errorDiv").Visible = false;
            Master.FindControl("successDiv").Visible = false;
            selectDevice.Visible=false;
            selectId.Visible = false;
            Label1.Visible = false;
            Label2.Visible = false;

        }

        

        protected void table_Select(object sender, EventArgs e)
        {
            location = selectLocation.SelectedValue;
            selectId.Visible = true;
            Label1.Visible = true;
            Label2.Visible = false;
            selectDevice.Visible = false;
            selectId_DataBinding();
        }

       

        protected void id_select(object sender, EventArgs e)
        {
            id = selectId.SelectedValue;
            selectId.Visible = true;
            Label1.Visible = true;
            Label2.Visible = true;
            selectDevice.Visible = true;
            selectDevice_DataBinding();
        }

        protected void device_select(object sender, EventArgs e)
        {

        }

        private void selectDevice_DataBinding()
        {
            DataTable dt_device_names;

            switch (location)
            {
                case "bay_line":
                    dt_device_names = new BL_BayLineDevice().selectAllDevices(id);
                    break;

                case "greenhouse":
                    dt_device_names = new BL_GreenhouseDevice().selectAllDevices(id);
                    break;

                //case "level":
                //    dt_device_names = new BL_BayRackLevelDevice().selectAllDevices(id);
                //    break;

                //case "level_line":
                //    dt_device_names = new BL_BayRackLevelLineDevice().selectAllDevices(id);
                //    break;

                case "rack":
                    dt_device_names = new BL_BayRackDevice().selectAllDevices(id);
                    break;

                default:
                    dt_device_names = new BL_BayDevice().selectAllDevices(id);
                    break;
            }

            
            //Map the list to the username list box.
            selectDevice.DataSource = dt_device_names;
            selectDevice.DataValueField = "device_unique_id";
            selectDevice.DataTextField = "device_unique_id";
            selectDevice.DataBind();

        }

        private void selectId_DataBinding()
        {
            DataTable dt_id_names = new BL_Greenhouse().selectUniqueIdsByTableName(location);
            selectId.DataSource = dt_id_names;
            selectId.DataValueField = location+"_id";
            selectId.DataTextField = location + "_unique_id";
            selectId.DataBind();

        }
    }
}