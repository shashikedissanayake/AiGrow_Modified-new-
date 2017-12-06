<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboardMaster.Master" AutoEventWireup="true" CodeBehind="AdminGreenHouses.aspx.cs" Inherits="AiGrow.Portal.Dashboards.Admin.AdminGreenHouses" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphH1Main" runat="server">
    Green Houses
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphH1Small" runat="server">
    Administration
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumbs" runat="server">
    Green Houses
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <center><button runat="server" id="addNewghButton" style="display: block; width: 220px; height: 40px; padding: 0; margin: 10px 20px 10px; font-weight: 700; color: #fff; background-color: #419325; border: none; border-radius: 20px; transition: background-color .10s ease-in-out; -webkit-user-select:none; -moz-user-select:none; -ms-user-select:none; user-select:none;" onserverclick="addNewgreenhouse">Create New Greenhouse</button></center>
    <form runat="server">
        <center> <dx:ASPxGridView ID="gvNetworks" runat="server" AutoGenerateColumns="False" OnDataBinding="gvNetworks_DataBinding" Width="80%">
            <SettingsEditing Mode="Inline">
                <BatchEditSettings EditMode="Row" StartEditAction="Click" />
            </SettingsEditing>
        <SettingsSearchPanel Visible="True"></SettingsSearchPanel>
<Columns>
            <dx:GridViewDataDateColumn FieldName="greenhouse_unique_id" Caption="Greenhouse ID" VisibleIndex="0"></dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="greenhouse_name" Caption="Greenhouse Name" VisibleIndex="1"></dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="owner" Caption="Owner" VisibleIndex="2"></dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="location_name" Caption="Location" VisibleIndex="3"></dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="location_address" Caption="Address" VisibleIndex="4"></dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="created_date" Caption="Created date" VisibleIndex="5"></dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="last_updated_date" Caption="Last updated" VisibleIndex="6"></dx:GridViewDataDateColumn>
            

                                                    <dx:GridViewDataTextColumn Caption="View" Name="View" VisibleIndex="11" Width="70px">
                                                <DataItemTemplate>
                                                    <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" NavigateUrl='<%# AiGrow.Constants.ADMIN_DASHBOARD_VIEW_GREEN_HOUSE+ "?greenhouseID=" + Eval("greenhouse_id") + "&token=" + AiGrow.Encryption.createSHA1(Eval("greenhouse_id").ToString()) %>' Text="View" />
                                                </DataItemTemplate>
                                                <HeaderTemplate>
                                                    <dx:ASPxLabel ID="ASPxLabel1" Text="View" runat="server" Font-Bold="True" Theme="MetropolisBlue" CssClass="dx-wrap" Style="font-size: Small; font-weight: bold; padding-left: 3px; padding-right: 3px; padding-top: 3px; padding-bottom: 3px;" />
                                                </HeaderTemplate>
                                                <Settings AllowAutoFilter="False" ShowFilterRowMenu="False" />
                                                <HeaderStyle VerticalAlign="Middle" />
                                                <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                                </CellStyle>

                                            </dx:GridViewDataTextColumn>

                                            <dx:GridViewDataTextColumn Caption="Edit" Name="Edit" VisibleIndex="12" Width="70px">
                                                <DataItemTemplate>
                                                    <dx:ASPxHyperLink ID="ASPxHyperLink2" runat="server" NavigateUrl='<%# AiGrow.Constants.ADMIN_DASHBOARD_GREEN_HOUSE_EDIT+ "?greenhouseID=" + Eval("greenhouse_id") + "&token=" + AiGrow.Encryption.createSHA1(Eval("greenhouse_id").ToString()) %>' Text="Edit" />
                                                </DataItemTemplate>
                                                <HeaderTemplate>
                                                    <dx:ASPxLabel ID="headingEdit" Text="Edit" runat="server" Font-Bold="True" Theme="MetropolisBlue" CssClass="dx-wrap" Style="font-size: Small; font-weight: bold; padding-left: 3px; padding-right: 3px; padding-top: 3px; padding-bottom: 3px;" />
                                                </HeaderTemplate>
                                                <Settings AllowAutoFilter="False" ShowFilterRowMenu="False" />
                                                <HeaderStyle VerticalAlign="Middle" />
                                                <CellStyle HorizontalAlign="Center" VerticalAlign="Middle">
                                                </CellStyle>

                                            </dx:GridViewDataTextColumn>


</Columns>
    </dx:ASPxGridView>
       </center>
        <p>Add component:</p>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="Bay">Bay</asp:ListItem>
            <asp:ListItem Value="BayLine">Bay Line</asp:ListItem>
            <asp:ListItem Value="bayLineDevices">Bay Line Devices</asp:ListItem>
            <asp:ListItem Value="level">Level</asp:ListItem>
            <asp:ListItem Value="levelLline">Level Line</asp:ListItem>
            <asp:ListItem Value="levelLineDevice">Level Line Device</asp:ListItem>
            <asp:ListItem Value="rack">Rack</asp:ListItem>
            <asp:ListItem Value="rackDevice">Rack Device</asp:ListItem>
        </asp:DropDownList>
        <br /><p>Select Green House:</p>
        
      <asp:DropDownList ID="selectGreenHouses" runat="server">
      </asp:DropDownList><br/>  
        <button runat="server" align="left" style="display: block; width: 130px; height: 40px; padding: 0; margin: 10px 20px 10px; font-weight: 700; color: #fff; background-color: #1cc6a7; border: none; border-radius: 20px; transition: background-color .10s ease-in-out; -webkit-user-select:none; -moz-user-select:none; -ms-user-select:none; user-select:none;">Add Component</button>
    </form>
    



</asp:Content>
