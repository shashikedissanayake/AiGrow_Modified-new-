<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboardMaster.Master" AutoEventWireup="true" CodeBehind="AdminEditGreenHouse.aspx.cs" Inherits="AiGrow.Portal.Dashboards.Admin.AdminEditGreenHouse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphH1Main" runat="server">
    Edit Green House
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphH1Small" runat="server">
    Administration
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumbs" runat="server">
    Edit Green Houses
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-xs-12">
            <div class="box">
                <div class="box-body">
                    <form id="frm_edit_network" runat="server">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:Literal ID="message" runat="server"></asp:Literal>
                        <asp:ValidationSummary ID="valSummaryForm" runat="server" CssClass="alert alert-dismissable alert-danger" />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="greenhouseId">Greenhouse Id: </label>
                                    <asp:TextBox ID="greenhouseId" MaxLength="100" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="requiredGreenhouseId" ValidationGroup="valGroup" ErrorMessage="This field is required!" ControlToValidate="greenhouseId" Display="Dynamic" CssClass="text-danger" runat="server"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label for="greenhouseName">Greenhouse Name:	 </label>
                                    <asp:TextBox ID="greenhouseName" MaxLength="100" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="requiredGreenhouseName" ValidationGroup="valGroup" ErrorMessage="This field is required!" ControlToValidate="greenhouseId" Display="Dynamic" CssClass="text-danger" runat="server"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label for="idGreenhouseOwner">Greenhouse Owner:	 </label>
                                    <asp:DropDownList ID="idGreenhouseOwner" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>


                            </div>
                        </div>


                    </form>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
