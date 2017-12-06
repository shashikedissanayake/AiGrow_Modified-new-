<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="AiGrow.Portal.ResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Reset Password - AiGrow</title>
    <link rel="shortcut icon" href="img/logo.png" />
    <link href="css/bootstrap.min.css" rel="stylesheet prefetch" />
<%
    
    String userName = Request.QueryString["username"];
    String email = Request.QueryString["email"];
    String valueError = Request.QueryString["error"];
    String token = Request.QueryString["token"];
    String token_email = Request.QueryString["token_email"];
    if (userName == null || email != AiGrow.Encryption.Base64Decode(token_email))
    {
        Response.Redirect(AiGrow.Constants.LOGIN_URL + "?error=" + AiGrow.Classes.Messages.invalidRequest + "&token=" + AiGrow.Encryption.createSHA1(AiGrow.Classes.Messages.invalidRequest));

    }
    else
    {
        userName = AiGrow.Encryption.Base64Decode(userName);

    }
            
%>
</head>
<body>
    
    <form id="form1" runat="server">
        <hr>
        <div class="container">
            <%
                //If "error" is returned the "alert-danger" div is displayed.
                //If "message" is returned the "alert-success" div is displayed.
                //Each value is validated against the SHA1 encryption value returned in the "token" variable. 
                String value = Request.QueryString["message"];
                String valueError = Request.QueryString["error"];
                String token = Request.QueryString["token"];
                if (value != null && token == AiGrow.Encryption.createSHA1(value))
                { 
            %>

            <div class="alert alert-dismissable alert-success">
                <button type="button" class="close" data-dismiss="alert">x</button>
                <strong>Message: </strong><% Response.Write(value); %>
            </div>
            <% }
                else if (valueError != null && token == AiGrow.Encryption.createSHA1(valueError))
                {              
            %>

            <div class="alert alert-dismissable alert-danger">
                <button type="button" class="close" data-dismiss="alert">x</button>
                <strong>Error: </strong><% Response.Write(valueError); %>
            </div>
            <% } %>

            <div class="row">
                <div class="row">
                    <div class="col-md-4 col-md-offset-4">
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <div class="text-center">
                                    <img class="img-circle" src="img/Aigrow_Logo.png" width="100" height="100" />
                                    <h2 class="text-center">AiGrow Portal</h2>
                                    <p>You can reset your password here.</p>
                                    <div class="panel-body">
                                        <fieldset>
                                            <div class="form-group">
                                                <asp:Label ID="txt_username" CssClass="form-control" runat="server"></asp:Label>
                                                <br />
                                                <asp:TextBox placeholder="Enter new password" ID="pass" MaxLength="100" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="valGroup" ErrorMessage="This field is required!" ControlToValidate="pass" Display="Dynamic" CssClass="text-danger" runat="server"></asp:RequiredFieldValidator>

                                                <br />
                                                <asp:TextBox ID="passConfirm" placeholder="Re-type password" MaxLength="100" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="requiredVerifyPassword" ValidationGroup="valGroup" ErrorMessage="This field is required!" ControlToValidate="passConfirm" Display="Dynamic" CssClass="text-danger" runat="server"></asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="comparePasswordValidator" ControlToValidate="passConfirm" ControlToCompare="pass" ErrorMessage="Passwords do not match!" CssClass="text-danger" runat="server" Display="Dynamic" ValidationGroup="valGroup"></asp:CompareValidator>
                                                <br />
                                            </div>
                                            <div class="form-group">
                                                <asp:Button ID="idSubmitButton" CssClass="btn btn-lg btn-primary btn-block" OnClick="submitButtonClick" runat="server" Text="Reset Password" ValidationGroup="valGroup" />
                                            </div>
                                        </fieldset>
                                    </div>
                                    <p><b><i>If you have trouble in resetting your password, feel free to contact us:</i></b></p>
                                    <% Response.Write(AiGrow.Constants.CONTACT_US_TEXT); %>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

</body>
</html>
