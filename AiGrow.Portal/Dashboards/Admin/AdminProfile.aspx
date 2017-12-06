<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboardMaster.Master" AutoEventWireup="true" CodeBehind="AdminProfile.aspx.cs" Inherits="AiGrow.Portal.Dashboards.Admin.AdminProfile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphH1Main" runat="server">
    <% String fullName = AiGrow.SessionHandler.getLoggedInUserFullName();
       Response.Write(fullName);  %>: Profile    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphH1Small" runat="server">
    Control panel    
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-xs-12">
            <div class="box">
                <div class="box-body">
                    <table id="idTablePointOwner" class="table table-bordered table-striped dataTable" role="grid">
                        <thead id="myTHead">
                            <tr role="row">
                                <th>Item</th>
                                <th>Value</th>
                            </tr>
                        </thead>
                        <tbody>

                            <% AiGrow.ChargeCustomer currentAdmin = new AiGrow.ChargeCustomer();
                               currentAdmin.getCustomerData();
                               
                            %>
                            <tr>
                                <td><b><% Response.Write("Title"); %></b></td>
                                <td><% Response.Write(currentAdmin.Title); %></td>
                            </tr>
                            <tr>
                                <td><b><% Response.Write("First Name"); %></b></td>
                                <td><% Response.Write(currentAdmin.FirstName); %></td>
                            </tr>
                            <tr>
                                <td><b><% Response.Write("Last Name"); %></b></td>
                                <td><% Response.Write(currentAdmin.LastName); %></td>
                            </tr>
                            <tr>
                                <td><b><% Response.Write("Address"); %></b></td>
                                <td><% Response.Write(currentAdmin.Address); %></td>
                            </tr>
                            <tr>
                                <td><b><% Response.Write("E-mail"); %></b></td>
                                <td><% Response.Write(currentAdmin.Email); %></td>
                            </tr>

                            <tr>
                                <td><b><% Response.Write("Country"); %></b></td>
                                <td><% Response.Write(currentAdmin.Country); %></td>
                            </tr>
                            <tr>
                                <td><b><% Response.Write("Gender"); %></b></td>
                                <td><% Response.Write(currentAdmin.Gender); %></td>
                            </tr>

                            <tr>
                                <td><b><% Response.Write("Organization Name"); %></b></td>
                                <td><% Response.Write(currentAdmin.OrganizationName); %></td>
                            </tr>
                            <tr>
                                <td><b><% Response.Write("Telephone"); %></b></td>
                                <td><% Response.Write(currentAdmin.Telephone); %></td>
                            </tr>
                            <tr>
                                <td><b><% Response.Write("Mobile"); %></b></td>
                                <td><% Response.Write(currentAdmin.Mobile); %></td>
                            </tr>
                            <tr>
                                <td><b><% Response.Write("User Name"); %></b></td>
                                <td><% Response.Write(currentAdmin.Username); %></td>
                            </tr>
                        </tbody>
                    </table>
                    <div class="form-group" style="text-align: center">
                        <a href="<% Response.Write(AiGrow.Constants.EDIT_PROFILE_URL_ADMIN);%>">
                            <button type="button" id="idSubmitButton" class="submit btn btn-info">Edit Profile</button></a>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBreadcrumbs" runat="server">
    Admin Profile
</asp:Content>
