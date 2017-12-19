using System;
using System.Collections.Generic;
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
            string greenhouseID = HttpContext.Current.Request.QueryString["greenhouse_id"];
            //get_visualize_dataset();
            StringBuilder strScript = new StringBuilder();
            strScript.Append(@"
            <script>
window.onload = function () {

var chart = new CanvasJS.Chart('chart', {
	animationEnabled: true,
	axisY2 :{
		includeZero: false,
		suffix:'℃'
	},
    axisY :{
		includeZero: false,
		suffix: '%'
	},
	toolTip: {
		shared: true
	},
	legend: {
		fontSize: 13
	},
	data: [{
		type: 'splineArea',
		showInLegend: true,
		name: 'Humidity',
		yValueFormatString: '##.00',
		xValueFormatString: 'MMM YYYY',
		dataPoints: [
			{ x: new Date(2016, 2), y: 91 },
			{ x: new Date(2016, 3), y: 95 },
			{ x: new Date(2016, 4), y: 90 },
			{ x: new Date(2016, 5), y: 90.4 },
			{ x: new Date(2016, 6), y: 90.9 },
			{ x: new Date(2016, 7), y: 91 },
			{ x: new Date(2016, 8), y: 90.2 },
			{ x: new Date(2016, 9), y: 90 },
			{ x: new Date(2016, 10), y: 93 },
			{ x: new Date(2016, 11), y: 98 },
			{ x: new Date(2017, 0),  y: 98.9 },
			{ x: new Date(2017, 1),  y: 99 }
		]
 	},{
		type: 'splineArea', 
		showInLegend: true,
		name: 'Temperature',
        axisYType: 'secondary',
		yValueFormatString: '###<sup>o</sup>c',     
		dataPoints: [
			{ x: new Date(2016, 2), y: 25 },
			{ x: new Date(2016, 3), y: 27 },
			{ x: new Date(2016, 4), y: 34 },
			{ x: new Date(2016, 5), y: 30 },
			{ x: new Date(2016, 6), y: 28 },
			{ x: new Date(2016, 7), y: 30 },
			{ x: new Date(2016, 8), y: 28 },
			{ x: new Date(2016, 9), y: 27 },
			{ x: new Date(2016, 10), y: 28.1 },
			{ x: new Date(2016, 11), y: 29 },
			{ x: new Date(2017, 0), y: 29.5 },
			{ x: new Date(2017, 1), y: 30 }
		]
 	},{
		type: 'splineArea', 
		showInLegend: true,
		name: 'CO2',
		yValueFormatString: '##.00',
		dataPoints: [
			{ x: new Date(2016, 2), y: 20.1 },
			{ x: new Date(2016, 3), y: 16 },
			{ x: new Date(2016, 4), y: 14 },
			{ x: new Date(2016, 5), y: 18 },
			{ x: new Date(2016, 6), y: 18 },
			{ x: new Date(2016, 7), y: 21 },
			{ x: new Date(2016, 8), y: 22},
			{ x: new Date(2016, 9), y: 25 },
			{ x: new Date(2016, 10), y: 23 },
			{ x: new Date(2016, 11), y: 25 },
			{ x: new Date(2017, 0), y: 26 },
			{ x: new Date(2017, 1), y: 25 }
		]
 	}]
});
chart.render();

}
</script>");
            ltScripts.Text = strScript.ToString();
        }
    }
}