<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboardMaster.Master" AutoEventWireup="true" CodeBehind="AdminGreenHouseView.aspx.cs" Inherits="AiGrow.Portal.Dashboards.Admin.AdminGreenHouseView" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphH1Main" runat="server">
View Green House
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphH1Small" runat="server">
    Administration
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumbs" runat="server">
    Green House View
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    .google-visualization-orgchart-node {
        font-family: Calibri !important;
        border: 2px solid transparent;
        background:#6eb2d9;
        
    }
</style>
    <script type="text/javascript" src="https://www.google.com/jsapi?autoload={'modules':[{'name':'visualization','version':'1','packages':['orgchart']}]}"></script>
    <form id="form1" runat="server">  
        <div>  
             <div id="chart_div">  
  
             </div>  
        </div>  
    </form> 
    
</asp:Content>
