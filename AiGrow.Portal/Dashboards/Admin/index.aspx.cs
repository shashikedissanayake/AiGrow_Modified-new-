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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.FindControl("errorDiv").Visible = false;
            Master.FindControl("successDiv").Visible = false;
                 
        }

        protected void get_visualize_dataset()
        {
            
            string location = "greenhouse";
            string device = "GD_001";
            DateTime time = new DateTime();
            time = DateTime.Now;
            DateTime fromTime = DateTime.Now.Date.AddMonths(-3).AddDays(-(DateTime.Now.Day)).AddDays(1);
            string from = fromTime.ToString();
            string to = time.ToString();

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
               // ltScripts.Text = "No Data.";
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
                    strScript.Append("['" + row["received_time"] + "'," + row["data"] + "],");
                }
                strScript.Remove(strScript.Length - 1, 1);
                strScript.Append("]);");

                strScript.Append("var options = { title: 'Device Data', titleTextStyle: {  fontName: 'Spectral SC', fontSize: '35', bold: 'true', italic: 'true' }, hAxis: { title: 'Time' }, vAxis: { title: 'Sensor Reading' }, legend: { position: 'right' } };");
                strScript.Append(" var chart = new google.visualization.LineChart(document.getElementById('salesChart'));  chart.draw(data, options); } google.setOnLoadCallback(drawVisualization);");
                strScript.Append(" </script>");

                //ltScripts.Text = strScript.ToString();
            }
            catch
            {
            }
            finally
            {
                strScript.Clear();
            }
        }
    }
}