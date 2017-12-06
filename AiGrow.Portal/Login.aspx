<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AiGrow.Portal.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

      <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <title>AiGrow login page</title>
    <link rel="shortcut icon" href="img/logo.png" />
    <link rel="stylesheet" href="css/style.css">


    <script src="https://s.codepen.io/assets/libs/modernizr.js" type="text/javascript"></script>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">

    <link rel='stylesheet prefetch' href='https://fonts.googleapis.com/css?family=Comfortaa:400,700'>
  
    <link rel="stylesheet" href="Dashboards/bower_components/font-awesome/css/font-awesome.min.css"

</head>
<body>
    <div class="container">

        
         <% 
             //If "error" is returned the "alert-danger" div is displayed.
             //If "message" is returned the "alert-success" div is displayed.
             //Each value is validated against the SHA1 encryption value returned in the "token" variable. 
             String value = Request.QueryString["message"];
             String valueError = Request.QueryString["error"];
             String token = Request.QueryString["token"];

             String message_enc = Request.QueryString["message_enc"];
             if (message_enc != null)
             {
                 String t = AiGrow.Encryption.createSHA1(message_enc);

             }

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
                <button type="button" class="close" style="background-color: Transparent;" data-dismiss="alert">x</button>
                <strong>Error: </strong><% Response.Write(valueError); %>
            </div>
            <% }
                else if (message_enc != null && token.Trim() == AiGrow.Encryption.createSHA1(System.Net.WebUtility.UrlEncode(message_enc.Trim())))
                { 
            %>
            <div class="alert alert-dismissable alert-danger">
                <button type="button" class="close" data-dismiss="alert">x</button>
                <strong>Error: </strong><% Response.Write(AiGrow.Encryption.Base64Decode((message_enc))); %>
            </div>
            <% } %>


        <div id="login" class="login">
            <!-- form submission--->
            <form class="form-horizontal" role="form" method="post" id="LoginForm" runat="server">
                
                <div class="login-icon-field">
                    <center><img src="../img/Aigrow_Logo.png" height="160px" width="160px" class="login-icon" /></center>
                </div>
                <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
                <div class="login-form">
                    <div class="username-row row">
                        <label for="username_input">
                            <svg version="1.1" class="user-icon" x="0px" y="0px"
                                viewBox="-255 347 100 100" xml:space="preserve" height="36px" width="30px">
                                <path class="user-path" d="
          M-203.7,350.3c-6.8,0-12.4,6.2-12.4,13.8c0,4.5,2.4,8.6,5.4,11.1c0,0,2.2,1.6,1.9,3.7c-0.2,1.3-1.7,2.8-2.4,2.8c-0.7,0-6.2,0-6.2,0
          c-6.8,0-12.3,5.6-12.3,12.3v2.9v14.6c0,0.8,0.7,1.5,1.5,1.5h10.5h1h13.1h13.1h1h10.6c0.8,0,1.5-0.7,1.5-1.5v-14.6v-2.9
          c0-6.8-5.6-12.3-12.3-12.3c0,0-5.5,0-6.2,0c-0.8,0-2.3-1.6-2.4-2.8c-0.4-2.1,1.9-3.7,1.9-3.7c2.9-2.5,5.4-6.5,5.4-11.1
          C-191.3,356.5-196.9,350.3-203.7,350.3L-203.7,350.3z" />
                            </svg>
                        </label>
                        <asp:TextBox ID="userName" ForeColor="White" placeholder="username" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valUsername" ControlToValidate="userName" runat="server" ValidationGroup="valGroup" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </div>
                    <div class="password-row row">
                        <label for="password_input">
                            <svg version="1.1" class="password-icon" x="0px" y="0px"
                                viewBox="-255 347 100 100" height="36px" width="30px">
                                <path class="key-path" d="M-191.5,347.8c-11.9,0-21.6,9.7-21.6,21.6c0,4,1.1,7.8,3.1,11.1l-26.5,26.2l-0.9,10h10.6l3.8-5.7l6.1-1.1
          l1.6-6.7l7.1-0.3l0.6-7.2l7.2-6.6c2.8,1.3,5.8,2,9.1,2c11.9,0,21.6-9.7,21.6-21.6C-169.9,357.4-179.6,347.8-191.5,347.8z" />
                            </svg>
                        </label>
                        <asp:TextBox ID="password" ForeColor="White" TextMode="Password" runat="server" MaxLength="100" placeholder="password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valPass" runat="server" ControlToValidate="password" ValidationGroup="valGroup" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                        
                        
                    </div>
                    <div class="forgot">
                    
                            <p class="login__signup"><i class="fa fa-lock"></i>&nbsp;<a href="ForgotPassword.aspx">Forgot password? </a></p>
                        </div>
                    <div class="call-to-action">
                      
                        <center>
                            <button id="loginButton" type="button" runat="server" onserverclick="signinClick" validationgroup="valGroup">Log In</button>
                        </center>
                        <p align="center">Don't have an account? <a href="signUp.aspx">Sign Up</a></p>
                    </div>
                </div>
        </div>
        <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
        <script src='https://cdn.jsdelivr.net/velocity/1.2.2/velocity.min.js'></script>
        <script src='https://cdn.jsdelivr.net/velocity/1.2.2/velocity.ui.min.js'></script>
        <script src="js/index.js"></script>
        </form>
            <!--    -->
</body>
</html>
