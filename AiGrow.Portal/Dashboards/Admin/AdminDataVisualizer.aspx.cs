using AiGrow.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
                selectDevice.Visible = false;
                selectId.Visible = false;
                Label1.Visible = false;
                Label2.Visible = false;
                table_Select(this,new EventArgs());
                RadioButtonList1.Visible = false;

            }


        }

        protected void table_Select(object sender, EventArgs e)
        {
            string selected = selectLocation.SelectedValue;
            selectId.Visible = true;
            Label1.Visible = true;
            Label1.Text = "Select "+selected+" unique id: \n\n";
            Label2.Visible = false;
            selectDevice.Visible = false;
            RadioButtonList1.Visible = false;
            ltScripts.Text = null;
            selectId_GetDataSet(selected);
        }


        protected void id_select(object sender, EventArgs e)
        {
            string id = selectId.SelectedValue;
            string location = selectLocation.SelectedValue;
            selectId.Visible = true;
            Label1.Visible = true;
            Label2.Visible = true;
            Label2.Text = "Select device: \n\n";
            selectDevice.Visible = true;
            ltScripts.Text = null;
            RadioButtonList1.Visible = false;
            selectDevice_GetDataSet(location, id);
        }

        protected void get_visualize_dataset(object sender, EventArgs e)
        {
            RadioButtonList1.Visible = true;
            string location = selectLocation.SelectedValue;
            string device = selectDevice.SelectedValue;
            string [] time = timePeriod(RadioButtonList1.SelectedIndex);
            string from = time[0];
            string to = time[1];

            DataTable dt_device_names;

            switch (location)
            {
                case "bay_line":
                    dt_device_names = new BL_BayLineDeviceData().selectDataSet(device,from,to);
                    break;

                case "greenhouse":
                    dt_device_names = new BL_GreenhouseDeviceData().selectDataSet(device, from, to);
                    break;

                case "level":
                    dt_device_names = new BL_BayRackLevelDeviceData().selectDataSet(device, from, to);
                    break;

                case "level_line":
                    dt_device_names = new BL_BayRackLevelLineDeviceData().selectDataSet(device, from, to);
                    break;

                case "rack":
                    dt_device_names = new BL_BayRackDeviceData().selectDataSet(device, from, to);
                    break;

                case "bay":
                    dt_device_names = new BL_BayDeviceData().selectDataSet(device, from, to);
                    break;

                default:
                    dt_device_names = null;
                    break;
            }
            if (dt_device_names.Rows.Count != 0)
            {
                BindChart(dt_device_names);
            }
            else
            {
                ltScripts.Text = "No Data.";
            }


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
                    function drawVisualization() {         
                    var data = google.visualization.arrayToDataTable([   
                    ['received_time', 'data'],");

                foreach (DataRow row in dsChartData.Rows)
                {
                    strScript.Append("['" + row["collected_time"] + "'," + row["data"] + "],");
                }
                strScript.Remove(strScript.Length - 1, 1);
                strScript.Append("]);");

                strScript.Append("var options = { title: 'Device Data', titleTextStyle: {  fontName: 'Spectral SC', fontSize: '35', bold: 'true', italic: 'true' }, hAxis: { title: 'Time' }, vAxis: { title: 'Sensor Reading' }, legend: { position: 'right' } };");
                strScript.Append(" var chart = new google.visualization.LineChart(document.getElementById('chart_div'));  chart.draw(data, options); } google.setOnLoadCallback(drawVisualization);");
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


        private void selectDevice_GetDataSet(string location, string id)
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

                default:
                    dt_device_names = null;
                    break;
            }

            selectDevice.DataSource = dt_device_names;
            selectDevice.DataValueField = "device_unique_id";
            selectDevice.DataTextField = "device_unique_id";
            if (dt_device_names.Rows.Count != 0)
            {
                selectDevice.DataBind();
                selectDevice.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                selectDevice.SelectedIndex = 0;
            }
            else
            {
                Label2.Visible = true;
                selectDevice.Visible = false;
                Label2.Text = "No devices found.";
            }
            
        }

        private void selectId_GetDataSet(string location)
        {
            DataTable dt_id_names = new BL_Greenhouse().selectUniqueIdsByTableName(location);
            selectId.DataSource = dt_id_names;
            selectId.DataValueField = "id";
            selectId.DataTextField = "unique_id";
            if (dt_id_names.Rows.Count != 0)
            {
                selectId.DataBind();
                selectId.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                selectId.SelectedIndex = 0;
            }
            else
            {
                selectId.Visible = false;
                Label1.Visible = true;
                Label1.Text = "No devices found.";
            }
            
        }

        protected void period_select(object sender, EventArgs e)
        {
            string location = selectLocation.SelectedValue;
            string device = selectDevice.SelectedValue;
            string[] time = timePeriod(RadioButtonList1.SelectedIndex);
            string from = time[0];
            string to = time[1];

            DataTable dt_device_names;

            switch (location)
            {
                case "bay_line":
                    dt_device_names = new BL_BayLineDeviceData().selectDataSet(device, from, to);
                    break;

                case "greenhouse":
                    dt_device_names = new BL_GreenhouseDeviceData().selectDataSet(device, from, to);
                    break;

                case "level":
                    dt_device_names = new BL_BayRackLevelDeviceData().selectDataSet(device, from, to);
                    break;

                case "level_line":
                    dt_device_names = new BL_BayRackLevelLineDeviceData().selectDataSet(device, from, to);
                    break;

                case "rack":
                    dt_device_names = new BL_BayRackDeviceData().selectDataSet(device, from, to);
                    break;

                case "bay":
                    dt_device_names = new BL_BayDeviceData().selectDataSet(device, from, to);
                    break;

                default:
                    dt_device_names = null;
                    break;
            }
            if (dt_device_names.Rows.Count != 0)
            {
                BindChart(dt_device_names);
            }
            else
            {
                ltScripts.Text = "No Data.";
            }

        }

        protected string [] timePeriod(int selected) {
            DateTime fromTime = new DateTime();
            DateTime toTime = new DateTime();
            if (selected == 0)
            {
                //Today
                fromTime = DateTime.Now.Date;
                toTime = DateTime.Now;
            }
            else if (selected == 1)
            {
                //This Month                
                fromTime = DateTime.Now.Date.AddDays(-(DateTime.Now.Day)).AddDays(1);
                //fromTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                toTime = DateTime.Now;
            }
            else if (selected == 2)
            {
                //3 months
                fromTime = DateTime.Now.Date.AddMonths(-3).AddDays(-(DateTime.Now.Day)).AddDays(1);
                toTime = DateTime.Now.Date.AddDays(-(DateTime.Now.Day)).AddDays(1);
                //toTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            }
            else if (selected == 3)
            {
                //All
                fromTime = new DateTime(1970, 1, 1);
                toTime = DateTime.Now;
            }
            string from = fromTime.ToString(Constants.MySQLDateFormat);
            string to = toTime.ToString(Constants.MySQLDateFormat);
            string [] time = {from,to};

            return time;
        
        }

    }
}