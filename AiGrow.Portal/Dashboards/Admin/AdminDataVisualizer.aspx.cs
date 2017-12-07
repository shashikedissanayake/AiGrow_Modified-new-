using AiGrow.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AiGrow.Portal.Dashboards.Admin
{
    public partial class AdminDataVisualizer : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) 
            { 
                Master.FindControl("errorDiv").Visible = false;
                Master.FindControl("successDiv").Visible = false;
                selectDevice.Visible=false;
                selectId.Visible = false;
                Label1.Visible = false;
                Label2.Visible = false;   
            }
            

        }

        protected void table_Select(object sender, EventArgs e)
        {
            string selected = selectLocation.SelectedValue;
            selectId.Visible = true;
            Label1.Visible = true;
            Label2.Visible = false;
            selectDevice.Visible = false;
            selectId_GetDataSet(selected);
        }


        protected void id_select(object sender, EventArgs e)
        {
            string id = selectId.SelectedValue;
            string location = selectLocation.SelectedValue;
            selectId.Visible = true;
            Label1.Visible = true;
            Label2.Visible = true;
            selectDevice.Visible = true;
            selectDevice_GetDataSet(location,id);
        }

        protected void device_select(object sender, EventArgs e)
        {
            string location = selectLocation.SelectedValue;
            string device = selectDevice.SelectedValue;

            DataTable dt_device_names;

            switch (location)
            {
                case "bay_line":
                    dt_device_names = new BL_BayLineDeviceData().selectDataSet(device);
                    break;

                case "greenhouse":
                    dt_device_names = new BL_GreenhouseDeviceData().selectDataSet(device);
                    break;

                case "level":
                    dt_device_names = new BL_BayRackLevelDeviceData().selectDataSet(device);
                    break;

                //case "level_line":
                //    dt_device_names = new BL_BayRackLevelLineDeviceData().selectDataSet(device);
                //    break;

                case "rack":
                    dt_device_names = new BL_BayRackDeviceData().selectDataSet(device);
                    break;

                case "bay":
                    dt_device_names = new BL_BayDeviceData().selectDataSet(device);
                    break;

                default:
                    dt_device_names = null;
                    break;
            }

            BindChart(dt_device_names);

        }

        private void BindChart(DataTable data)
        {
            DataTable dsChartData;
            StringBuilder strScript = new StringBuilder();
            try
            {
                dsChartData = data;

                strScript.Append(@"<script type='text/javascript'>  
                    google.load('visualization', '1', {packages: ['corechart']});</script>  
  
                    <script type='text/javascript'>  
                    function drawChart() {         
                    var data = google.visualization.arrayToDataTable([  
                    ['received_time', 'data'],");

                foreach (DataRow row in dsChartData.Rows)
                {
                    strScript.Append("['" + row["received_time"] + "'," + row["data"] + "],");
                }
                strScript.Remove(strScript.Length - 1, 1);
                strScript.Append("]);");

                strScript.Append("var options = { title: 'Device Data', curveType: 'function', legend: { position: 'bottom' } };");
                strScript.Append(" var chart = new google.visualization.LineChart(document.getElementById('chart_div'));  chart.draw(data, options); } google.setOnLoadCallback(drawChart);");
                strScript.Append(" </script>");

                ltScripts.Text = strScript.ToString();
            }
            catch
            {
            }
            finally
            {

                strScript.Clear();
            }
        }
 

        private void selectDevice_GetDataSet(string location,string id)
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

                case "level":
                    dt_device_names = new BL_BayRackLevelDevice().selectAllDevices(id);
                    break;

                case "level_line":
                    dt_device_names = new BL_BayRackLevelLineDevice().selectAllDevices(id);
                    break;

                case "rack":
                    dt_device_names = new BL_BayRackDevice().selectAllDevices(id);
                    break;

                case "bay":
                    dt_device_names = new BL_BayDevice().selectAllDevices(id);
                    break;

                default :
                    dt_device_names = null;
                    break;
            }

            selectDevice.DataSource = dt_device_names;
            selectDevice.DataValueField = "device_unique_id";
            selectDevice.DataTextField = "device_unique_id";
            selectDevice.DataBind();
        }

        private void selectId_GetDataSet(string location)
        {
            DataTable dt_id_names = new BL_Greenhouse().selectUniqueIdsByTableName(location);
            selectId.DataSource = dt_id_names;
            selectId.DataValueField = "id";
            selectId.DataTextField = "unique_id";
            selectId.DataBind();
        }

       
    }
}