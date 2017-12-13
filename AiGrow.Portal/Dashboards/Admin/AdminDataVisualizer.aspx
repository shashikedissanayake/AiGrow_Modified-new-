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
            <asp:ListItem Value="bay" Selected="True">Bay</asp:ListItem>
            <asp:ListItem Value="bay_line">Bay Line</asp:ListItem>
            <asp:ListItem Value="greenhouse">Greenhouse</asp:ListItem>
            <asp:ListItem Value="level">Level</asp:ListItem>
            <asp:ListItem Value="level_line">Level Line</asp:ListItem>
            <asp:ListItem Value="rack">Rack</asp:ListItem>
        </asp:DropDownList>

        <asp:Label ID="Label1" runat="server" Style="display: block;"></asp:Label><br />

        <asp:DropDownList ID="selectId" runat="server" AutoPostBack="True" OnSelectedIndexChanged="id_select">
        </asp:DropDownList><br />

        <asp:Label ID="Label2" runat="server" Style="display: block"></asp:Label><br />

        <asp:DropDownList ID="selectDevice" runat="server" AutoPostBack="True" OnSelectedIndexChanged="get_visualize_dataset">
        </asp:DropDownList><br />
        <div>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" TabIndex="3" AutoPostBack="True" OnSelectedIndexChanged="period_select">
                <asp:ListItem Value="1 DAY">Today</asp:ListItem>
                <asp:ListItem Value="1 MONTH">This Month</asp:ListItem>
                <asp:ListItem Value="3 MONTH">Last 3 Month</asp:ListItem>
                <asp:ListItem Value="all" Selected="True">All</asp:ListItem>
            </asp:RadioButtonList>
            <script type="text/javascript" src="https://www.google.com/jsapi"></script>
            <center>
                <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
                <div id="chart_div" style="width: 800px; height: 400px;"> 
                </div>
            </center>
        </div>


    </form>
</asp:Content>
