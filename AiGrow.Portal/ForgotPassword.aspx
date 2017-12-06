<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="AiGrow.Portal.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password-AiGrow</title>
    <link rel="shortcut icon" href="img/logo.png" />
    <link href="css/bootstrap.min.css" rel="stylesheet prefetch" />

</head>
<body>
   
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
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
                        <%--                        <strong>Message: </strong><% Response.Write(value); %>--%>
                    </div>
                    <% }
                        else if (valueError != null && token == AiGrow.Encryption.createSHA1(valueError))
                        {              
                    %>

                    <div class="alert alert-dismissable alert-danger">
                        <button type="button" class="close" data-dismiss="alert">x</button>
                        <%--                        <strong>Error: </strong><% Response.Write(valueError); %>--%>
                    </div>
                    <% } %>

                    <div class="row">
                        <div class="row">
                            <div class="col-md-4 col-md-offset-4">
                                <div class="panel panel-default">
                                    <div class="panel-body">
                                        <div class="text-center">
                                            <img class="img-circle" src="../img/Aigrow_Logo.png" width="100" height="100" />
                                            <h2 class="text-center">AiGrow Portal</h2>
                                            <p>You can reset your password here.</p>
                                            <div class="panel-body">
                                                <fieldset>
                                                    <div class="form-group">
                                                        <asp:TextBox placeholder="Enter your username" ID="txtUsername" MaxLength="100" CssClass="form-control" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="valGroup" ErrorMessage="This field is required!" ControlToValidate="txtUsername" Display="Static" CssClass="text-danger" runat="server"></asp:RequiredFieldValidator>
                                                        <br />
                                                        <asp:Label ID="lblError" runat="server" CssClass="text-danger" Text=""></asp:Label>
                                                        <br />
                                                    </div>
                                                    <div class="form-group">
                                                        <asp:Button ID="idSubmitButton" CssClass="btn btn-lg btn-primary btn-block" OnClick="submitButtonClick" runat="server" Text="Send Reset Link" ValidationGroup="valGroup" />
                                                    </div>
                                                </fieldset>
                                            </div>
                                            <p><b><i>If you have trouble in resetting your password, feel free to contact us:</i></b></p>
                                            <div>
                                                <address>
                                                    chargeNET Pvt. Ltd.,<br>
                                                    Trace Expert City,<br>
                                                    Tripoli Square,<br>
                                                    Maradana,<br>
                                                    Colombo 10.<br>
                                                </address>
                                                <p>
                                                    Tel. No.: +94 115 551 551<br>
                                                    E-Mail: <a href="mailto:info@chargenet.lk">info@chargenet.lk</a>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <div style="margin: 0 auto; position: fixed; z-index: 999; height: 100%; width: 100%; top: 0; left: 0; right: auto; background-color: #2c3e50; opacity: 0.7;">
                    <div style="z-index: 1000; position: absolute; top: 50%; left: 50%; margin-top: -50px; margin-left: -50px;">
                        <img src="img/background.jpg" />
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </form>

</body>
</html>
