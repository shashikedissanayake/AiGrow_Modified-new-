<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboardMaster.Master" AutoEventWireup="true" CodeBehind="AdminDataVisualizer.aspx.cs" Inherits="AiGrow.Portal.Dashboards.Admin.AdminDataVisualizer" %>

<%@ Register Assembly="DevExpress.XtraCharts.v16.2.Web, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dx" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.XtraCharts" Assembly="DevExpress.XtraCharts.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphH1Main" runat="server">
    Data Visualization
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphH1Small" runat="server">
    Administration
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumbs" runat="server">
    Data Visualizer
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
        <p>Select Location of the Device:</p>
        <asp:DropDownList ID="selectLocation" runat="server" OnSelectedIndexChanged="table_Select" AutoPostBack="True">
            <asp:ListItem Value="bay">Bay</asp:ListItem>
            <asp:ListItem Value="bay_line">Bay Line</asp:ListItem>
            <asp:ListItem Value="greenhouse">Greenhouse</asp:ListItem>
            <asp:ListItem Value="level">Level</asp:ListItem>
            <asp:ListItem Value="level_line">Level Line</asp:ListItem>
            <asp:ListItem Value="rack">Rack</asp:ListItem>
        </asp:DropDownList><br />

        <asp:Label ID="Label1" runat="server" Text="Select Unique ID:"></asp:Label><br />

        <asp:DropDownList ID="selectId" runat="server" AutoPostBack="True" OnSelectedIndexChanged="id_select"></asp:DropDownList><br />

        <asp:Label ID="Label2" runat="server" Text="Select Unique Component:"></asp:Label><br />

        <asp:DropDownList ID="selectDevice" runat="server" AutoPostBack="True" OnSelectedIndexChanged="device_select"></asp:DropDownList>
        <div>  
        <script type="text/javascript" src="https://www.google.com/jsapi"></script>  
        <asp:GridView ID="gvData" runat="server">  
        </asp:GridView>  
        <br />  
        <br />  
        <asp:Literal ID="ltScripts" runat="server"></asp:Literal>  
        <div id="chart_div" style="width: 660px; height: 400px;">  
        </div>  
    </div> 


    </form>
</asp:Content>
