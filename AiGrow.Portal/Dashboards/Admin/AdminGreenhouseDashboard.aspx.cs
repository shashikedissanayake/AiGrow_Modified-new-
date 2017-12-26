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
    public partial class AdminGreenhouseDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.FindControl("errorDiv").Visible = false;
            Master.FindControl("successDiv").Visible = false;
            if (!IsPostBack) { 
                string[] time = timePeriod(RadioButtonList1.SelectedIndex);
                string from = time[0];
                string to = time[1];
                graphRendering(from, to);
            }
            
        }

        protected void graphRendering(string from, string to)
        {

            string greenhouseID = HttpContext.Current.Request.QueryString["greenhouse_id"];


            StringBuilder strScript = new StringBuilder();
            strScript.Append(@"
            <script>
            window.onload = function () {

                var chart = new CanvasJS.Chart('chart', {
                    animationEnabled: true,
                    axisY2: {
                        title: 'Temperature',
                        lineColor: '#369EAD',
                        tickColor: '#369EAD',
                        labelFontColor: '#369EAD',
                        titleFontColor: '#369EAD',
                        includeZero: false,
                        suffix: '℃'
                    },
                    axisY: [{
                        title: 'Humidity',
                        lineColor: '#369EAD',
                        tickColor: '#369EAD',
                        labelFontColor: '#369EAD',
                        titleFontColor:'#369EAD',
                        includeZero: false,
                        suffix: '%'
                    }, {

                        title: 'co2',
                        lineColor: '#369EAD',
                        tickColor: '#369EAD',
                        labelFontColor: '#369EAD',
                        titleFontColor: '#369EAD',
                        suffix: 'ppm'

                    }],
                    toolTip: {
                        shared: true
                    },
                    legend: {
                        fontSize: 13
                    },
                    data: [{
                        type: 'spline',
                        fillOpacity: .3,
                        showInLegend: true,
                        name: 'Humidity',
                        axisYIndex: 0,
                        yValueFormatString: '##.00',
                        xValueFormatString: 'MMM YYYY',
                        dataPoints: [");
            DataTable dt_humidity = new BL_GreenhouseDeviceData().selectDeviceDataSetByType(greenhouseID, Constants.HUMIDITY_SENSOR, from, to);
            foreach (DataRow data in dt_humidity.Rows)
            {
                strScript.Append("{ x: new Date(Date.parse('" + data["collected_time"] + "'.replace('-', '/', 'g')))" + ", y: " + data["data"] + "},");
            }
           // strScript.Remove(strScript.Length - 1, 1);
            strScript.Append(@"]
 }, {
                        type: 'spline',
                        showInLegend: true,
                        name: 'Temperature',
                        axisYType: 'secondary',
                        yValueFormatString: '###<sup>o</sup>c',
                        dataPoints: [");
            DataTable dt_temperature = new BL_GreenhouseDeviceData().selectDeviceDataSetByType(greenhouseID, Constants.TEMPERATURE_SENSOR, from, to);
            foreach (DataRow data in dt_temperature.Rows)
            {
                strScript.Append("{ x: new Date(Date.parse('" + data["collected_time"] + "'.replace('-', '/', 'g')))" + ", y: " + data["data"] + "},");
            }

            strScript.Append(@"]
                    }, {
                        type: 'spline',
                        showInLegend: true,
                        name: 'CO2',
                        axisYIndex: 1,
                        yValueFormatString: '##.00',
                        dataPoints: [");
            DataTable dt_co2 = new BL_GreenhouseDeviceData().selectDeviceDataSetByType(greenhouseID, Constants.CO2_SENSOR, from, to);
            foreach (DataRow data in dt_co2.Rows)
            {
                strScript.Append("{ x: new Date(Date.parse('" + data["collected_time"] + "'.replace('-', '/', 'g')))" + ", y: " + data["data"] + "},");
            }
            strScript.Append(@"]
                        }]
                        });
                    chart.render();

                    }
                </script>");
            ltScripts.Text = strScript.ToString();

        }

        protected string[] timePeriod(int selected)
        {
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
                toTime = DateTime.Now;
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
            string[] time = { from, to };

            return time;

        }

        protected void period_select(object sender, EventArgs e)
        {
            string[] time = timePeriod(RadioButtonList1.SelectedIndex);
            string from = time[0];
            string to = time[1];
            graphRendering(from, to);
        }


    }
}