<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboardMaster.Master" AutoEventWireup="true" CodeBehind="AdminEditProfile.aspx.cs" Inherits="AiGrow.Portal.Dashboards.Admin.AdminEditProfile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphH1Main" runat="server">
    <% String userName = AiGrow.SessionHandler.getLoggedInUsername();
       Response.Write(userName);  %>: Edit Profile    
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphH1Small" runat="server">
    Control panel  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumbs" runat="server">
    Edit Profile
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

    <form id="frm_register" runat="server">

        <asp:Literal ID="message" runat="server"></asp:Literal>

        <asp:ValidationSummary ID="valSummaryForm" runat="server" CssClass="alert alert-dismissable alert-danger" ShowMessageBox="false" ShowSummary="true" ValidationGroup="valGroup" />


        <div class="row">
            <div class="col-md-7">
                <div class="form-group">
                    <label for="id_img">Current Profile Picture: </label>
                    <center><img width="200" height="200" <% Response.Write("src=\"" + AiGrow.MyUser.getProfileImageURL() + "\""); %> class="img-responsive" alt="User Image" />
                </center>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label for="cbo_title">Title: </label>
                    <asp:DropDownList ID="cbo_title" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                        <asp:ListItem Text="Mr" Value="Mr" />
                        <asp:ListItem Text="Mrs" Value="Mrs" />
                        <asp:ListItem Text="Ms" Value="Ms" />
                        <asp:ListItem Text="Rev" Value="Rev" />
                    </asp:DropDownList>
                </div>
            </div>

            <div class="col-md-4">
                <div class="form-group">
                    <label for="idFirstName">First Name: </label>
                    <asp:TextBox ID="idFirstName" MaxLength="20" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="requiredFirstName" ValidationGroup="valGroup" ErrorMessage="This field is required!" ControlToValidate="idFirstName" Display="Dynamic" CssClass="text-danger" runat="server"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label for="idLastName">Last Name: </label>
                    <asp:TextBox ID="idLastName" MaxLength="20" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="requiredLastName" ValidationGroup="valGroup" ErrorMessage="This field is required!" ControlToValidate="idLastName" Display="Dynamic" CssClass="text-danger" runat="server"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <label for="id_txt_address">Address: </label>
                    <asp:TextBox CssClass="form-control" ID="id_txt_address" TextMode="multiline" Rows="4" runat="server" />
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label for="id_txt_password">Password: </label>

                    <asp:TextBox ID="id_txt_password" placeholder="Keep blank if you do not want to change the password." MaxLength="100" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>

                    <asp:CustomValidator ID="cvPassword" runat="server" ValidationGroup="valGroup" ErrorMessage="Passwords do not match!" ControlToValidate="id_txt_password" CssClass="text-danger" ClientValidationFunction="validatePassword" Display="Dynamic">
                    </asp:CustomValidator>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label for="id_txt_verify_password">Verify Password: </label>
                    <asp:TextBox ID="id_txt_verify_password" MaxLength="100" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:CompareValidator ID="comparePasswordValidator" ControlToValidate="id_txt_verify_password" ControlToCompare="id_txt_password" ErrorMessage="Passwords do not match!" CssClass="text-danger" runat="server" Display="Dynamic" ValidationGroup="valGroup"></asp:CompareValidator>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label for="lst_countries">Country: </label>
                    <asp:DropDownList ID="lst_countries" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                    </asp:DropDownList>
                </div>
            </div>

            <div class="col-md-6">
                <div class="form-group">
                    <label for="id_txt_email">E-mail: </label>
                    <asp:TextBox ID="id_txt_email" MaxLength="200" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>

                    <asp:CustomValidator ID="cvEmail" runat="server" ValidationGroup="valGroup" ErrorMessage="Duplicate email. Please enter a different value." ControlToValidate="id_txt_email" CssClass="text-danger" ClientValidationFunction="validateEmail" Display="Dynamic"></asp:CustomValidator>

                    <asp:RegularExpressionValidator ID="regexEmailValid" ValidationGroup="valGroup" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="id_txt_email" CssClass="text-danger" Display="Dynamic" ErrorMessage="Invalid email. Please re-check!"></asp:RegularExpressionValidator>

                    <asp:RequiredFieldValidator ID="requiredEmail" ValidationGroup="valGroup" ErrorMessage="This field is required!" ControlToValidate="id_txt_email" Display="Dynamic" CssClass="text-danger" runat="server"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label for="id_txt_mobile">Mobile: </label>
                    <asp:TextBox placeholder="+94-XX-XXXXXXX" ID="id_txt_mobile" MaxLength="15" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="requiredMobile" ValidationGroup="valGroup" ErrorMessage="This field is required!" ControlToValidate="id_txt_mobile" Display="Dynamic" CssClass="text-danger" runat="server"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="numberMobile" runat="server" ControlToValidate="id_txt_mobile" Type="Integer" Display="Dynamic" CssClass="text-danger" runat="server" Operator="DataTypeCheck" ValidationGroup="valGroup" ErrorMessage="Enter a valid mobile number!" />
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label for="id_txt_telephone">Telephone: </label>
                    <asp:TextBox ID="id_txt_telephone" placeholder="+94-XX-XXXXXXX" MaxLength="15" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:CompareValidator ID="cvTelephone" runat="server" ControlToValidate="id_txt_telephone" Type="Integer" Display="Dynamic" CssClass="text-danger" runat="server" Operator="DataTypeCheck" ValidationGroup="valGroup" ErrorMessage="Enter a valid telephone number!" />

                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label for="cbo_gender">Gender: </label>
                    <asp:DropDownList ID="cbo_gender" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                        <asp:ListItem Text="Male" Value="Male" />
                        <asp:ListItem Text="Female" Value="Female" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label for="id_txt_org_name">Organization Name: </label>
                    <asp:TextBox ID="id_txt_org_name" MaxLength="100" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="form-group" style="display: none;">
            <label for="id_txt_username">Username: </label>
            <asp:TextBox ID="id_txt_username" MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>
            <%--<asp:RequiredFieldValidator ID="requiredUsername" ValidationGroup="valGroup" ErrorMessage="This field is required!" ControlToValidate="id_txt_username" Display="Dynamic" CssClass="text-danger" runat="server"></asp:RequiredFieldValidator>--%>
        </div>

        <div class="col-lg-12">
            <div class="form-group" style="text-align: center">
                <asp:Button ID="idSubmitButton" CssClass="submit btn btn-success" OnClick="submitButtonClick" runat="server" Text="Save Profile" ValidationGroup="valGroup" />
            </div>
        </div>
        <br />
        <br />

        <div id="loadingAnimation" style="display: none">
            <div style="margin: 0 auto; position: fixed; z-index: 999; height: 100%; width: 100%; top: 0; left: 0; right: auto; background-color: #2c3e50; opacity: 0.7;">
                <div style="z-index: 1000; position: absolute; top: 50%; left: 50%; margin-top: -50px; margin-left: -50px;">
                    <img src="/Dashboards/dist/img/Preloader_3.gif" />
                </div>
            </div>
        </div>


    </form>

</asp:Content>
