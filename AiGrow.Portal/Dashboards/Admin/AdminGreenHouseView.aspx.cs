using AiGrow.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AiGrow.Portal.Dashboards.Admin
{
    public partial class AdminGreenHouseView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.FindControl("errorDiv").Visible = false;
            Master.FindControl("successDiv").Visible = false;
            if (!IsPostBack)
            {
                BindData();
            }
        }

        

        private void BindData()
        {
            string greenhouseID = HttpContext.Current.Request.QueryString["greenhouseID"];
            string str = "";
            DataSet ds = new BL_Greenhouse().selectComponentsByNetworkID(greenhouseID);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                str = str + "['" + dr["bay_unique_id"].ToString() + "','" + dr["greenhouse_unique_id"].ToString() + "'],";
            }
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                str = str + "['" + dr["bay_line_unique_id"].ToString() + "','" + dr["bay_unique_id"].ToString() + "'],";
            }
            foreach (DataRow dr in ds.Tables[2].Rows)
            {
                if (!dr["rack_unique_id"].ToString().Equals(""))
                    str = str + "['<div style=\"background:#52f2f2;\">" + dr["rack_unique_id"].ToString() + "</div>" + "','" + dr["bay_unique_id"].ToString() + "'],";
                
            }
            foreach (DataRow dr in ds.Tables[3].Rows)
            {
                str = str + "['" + dr["level_unique_id"].ToString() + "','<div style=\"background:#52f2f2;\">" + dr["rack_unique_id"].ToString() + "</div>" + "'],";
            }
            foreach (DataRow dr in ds.Tables[4].Rows)
            {
                
                str = str + "['" + dr["level_line_unique_id"].ToString() + "','" + dr["level_unique_id"].ToString() + "'],";
            }
            str.Trim(',');

            String csname1 = "PopupScript";
            ClientScriptManager cs = Page.ClientScript;
            if (!cs.IsStartupScriptRegistered(typeof(Button), csname1))
            {
                StringBuilder scriptText = new StringBuilder();
                scriptText.Append("<script>");
                scriptText.Append("google.setOnLoadCallback(drawChart);");
                scriptText.Append("function drawChart() {");
                scriptText.Append("var data = new google.visualization.DataTable();");
                scriptText.Append("data.addColumn('string', 'Name'); data.addColumn('string', 'Manager');");
                scriptText.Append("data.addRows([" + str + "]);");
                scriptText.Append("var chart = new google.visualization.OrgChart(document.getElementById('chart_div'));");
                scriptText.Append("chart.draw(data, { allowHtml: true });");
                scriptText.Append("}");

                scriptText.Append("</script>");

                cs.RegisterStartupScript(typeof(Button), csname1, scriptText.ToString());
            }
        }    

    }
}