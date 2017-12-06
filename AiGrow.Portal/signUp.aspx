<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signUp.aspx.cs" Inherits="AiGrow.Portal.signUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/css/bootstrap.min.css" integrity="sha384-PsH8R72JQ3SOdhVi3uxftmaW6Vc51MKb0q5P2rRUpPvrszuE4W1povHYgTpBfshb" crossorigin="anonymous">
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <title>Register for AiGrow</title>
    <link rel="shortcut icon" href="img/logo.png" />
    <link href="css/error-css.css" rel="stylesheet" />
</head>
 
<body class="contain">

    <style>
        @media (min-width: 1200px) {
            .container {
                max-width: 800px;
            }
        }
    </style>
    <div class="container">
        <%-- <script type="text/javascript">
            alertify.alert('Ready!');
        </script>--%>

        <div>
            <center><img style="text-align: center" src="img/Aigrow_Logo.png" class="img-responsive" width="300" height="300" />
            <h2>Create an account</h2></center>
        </div>


        <br />

        <form id="frm_register" runat="server">

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
            <asp:Literal ID="message" runat="server"></asp:Literal>

            <div id="errorDiv" runat="server" class="alert alert-dismissable alert-danger">
                <button type="button" class="close" data-dismiss="alert">x</button>
                <strong id="strongText" runat="server">Error:</strong>
                <div id="errorMessage" runat="server"></div>
            </div>

            <div class="row" style="z-index: 2">
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
                        <label for="lst_countries">Country: </label>
                        <asp:DropDownList ID="lst_countries" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="form-group">
                        <label for="id_txt_email">E-mail: </label>
                        <asp:TextBox ID="id_txt_email" MaxLength="200" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>

                        <asp:RegularExpressionValidator ID="regexEmailValid" ValidationGroup="valGroup" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="id_txt_email" CssClass="text-danger" Display="Dynamic" ErrorMessage="Invalid email. Please re-check!"></asp:RegularExpressionValidator>

                        <asp:RequiredFieldValidator ID="requiredEmail" ValidationGroup="valGroup" ErrorMessage="This field is required!" ControlToValidate="id_txt_email" Display="Dynamic" CssClass="text-danger" runat="server"></asp:RequiredFieldValidator>

                        <asp:CustomValidator ID="cvEmail" runat="server" ValidationGroup="valGroup" ErrorMessage="Duplicate email! Please enter a different email." ControlToValidate="id_txt_email" CssClass="text-danger" ClientValidationFunction="validateEmail" Display="Dynamic">
                        </asp:CustomValidator>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label for="id_txt_username">Username: </label>
                        <asp:TextBox ID="id_txt_username" MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="requiredUsername" ValidationGroup="valGroup" ErrorMessage="This field is required!" ControlToValidate="id_txt_username" Display="Dynamic" CssClass="text-danger" runat="server"></asp:RequiredFieldValidator>

                        <asp:CustomValidator ID="cvUsername" runat="server" ValidationGroup="valGroup" ErrorMessage="Duplicate username! Please enter a different value." ControlToValidate="id_txt_username" CssClass="text-danger" ClientValidationFunction="validateUsername" Display="Dynamic"></asp:CustomValidator>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label for="id_txt_password">Password: </label>
                        <asp:TextBox ID="id_txt_password" MaxLength="100" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>

                        <asp:RegularExpressionValidator ID="regexPassword" ValidationGroup="valGroup" runat="server" ValidationExpression="^[\s\S]{6,}$" ControlToValidate="id_txt_password" CssClass="text-danger" Display="Dynamic" ErrorMessage="The password should be at least 6 characters long."></asp:RegularExpressionValidator>

                        <asp:RequiredFieldValidator ID="requiredPassword" ValidationGroup="valGroup" ErrorMessage="This field is required!" ControlToValidate="id_txt_password" Display="Dynamic" CssClass="text-danger" runat="server"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label for="id_txt_verify_password">Verify Password: </label>
                        <asp:TextBox ID="id_txt_verify_password" MaxLength="100" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="requiredVerifyPassword" ValidationGroup="valGroup" ErrorMessage="This field is required!" ControlToValidate="id_txt_verify_password" Display="Dynamic" CssClass="text-danger" runat="server"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="comparePasswordValidator" ControlToValidate="id_txt_verify_password" ControlToCompare="id_txt_password" ErrorMessage="Passwords do not match!" CssClass="text-danger" runat="server" Display="Dynamic" ValidationGroup="valGroup"></asp:CompareValidator>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label for="id_txt_telephone">Telephone: </label>
                        <asp:TextBox ID="id_txt_telephone" placeholder="+94-XX-XXXXXXX" MaxLength="15" CssClass="form-control" runat="server"></asp:TextBox>

                        <asp:RegularExpressionValidator ID="regexTelephone" ValidationGroup="valGroup" runat="server" ValidationExpression="(\+\d{1,3}[- ]?)?\d{10}" ControlToValidate="id_txt_telephone" CssClass="text-danger" Display="Dynamic" ErrorMessage="Invalid telephone no. Please re-check!"></asp:RegularExpressionValidator>

                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <label for="id_txt_mobile">Mobile: </label>
                        <asp:TextBox placeholder="+94-XX-XXXXXXX" ID="id_txt_mobile" MaxLength="15" CssClass="form-control" runat="server"></asp:TextBox>

                        <asp:RegularExpressionValidator ID="regexMobileValid" ValidationGroup="valGroup" runat="server" ValidationExpression="(\+\d{1,3}[- ]?)?\d{10}" ControlToValidate="id_txt_mobile" CssClass="text-danger" Display="Dynamic" ErrorMessage="Invalid mobile. Please re-check!"></asp:RegularExpressionValidator>

                        <asp:RequiredFieldValidator ID="requiredMobile" ValidationGroup="valGroup" ErrorMessage="This field is required!" ControlToValidate="id_txt_mobile" Display="Dynamic" CssClass="text-danger" runat="server"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label for="cbo_gender">Gender: </label>
                        <asp:DropDownList ID="cbo_gender" runat="server" AppendDataBoundItems="true" CssClass="form-control">
                            <asp:ListItem Text="Male" Value="Male" />
                            <asp:ListItem Text="Female" Value="Female" />
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <label for="id_txt_org_name">Organization Name: </label>
                        <asp:TextBox ID="id_txt_org_name" MaxLength="100" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="col-lg-12" style="text-align: center">
                <div class="form-group">
                    <button type="button" class="btn btn-primary btn-lg" onclick="location.href='http://chargenet.lk'">Go To Home</button>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="idSubmitButton" CssClass="submit btn btn-success btn-lg" OnClick="submitButtonClick" runat="server" Text="Register Now" ValidationGroup="valGroup" />
                </div>
            </div>
        </form>
        <br />
        <br />
        <br />
        <hr />
        <footer>
            <div class="panel-footer">
                <center><b>chargeNET Pvt. Ltd. - Trace Expert City, Tripoli Market, Maradana, Sri Lanka. info@chargenet.lk +94-11-5551-551	</b></center>
            </div>
        </footer>
    </div>
    <script type="text/javascript" src="js/sha1.js"></script>
    <script type="text/javascript">

        function validateUsername(oSrc, args) {
            $val = args.Value;
            $token = Sha1.hash($val.trim()).toUpperCase();
            var jsonText = JSON.stringify({ userName: $val, token: $token });

            $.ajax({
                type: "POST",
                url: "<%: AiGrow.Constants.VALIDATE_USERNAME %>",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonText,
                async: false,
                success: function (msg) {
                    var jsonObj = JSON.parse(msg.d);
                    if (String(jsonObj["success"]).bool() && String(jsonObj["message"]).bool()) {
                        args.IsValid = false;
                    } else {
                        args.IsValid = true;
                    }
                },
                error: function (msg) {
                    console.log(msg.d);
                }
            });
        }

        String.prototype.bool = function () {
            return (/^true$/i).test(this);
        };


        function validateEmail(oSrc, args) {
            $val = args.Value;
            $token = Sha1.hash($val.trim()).toUpperCase();
            var jsonText = JSON.stringify({ email: $val, token: $token });

            $.ajax({
                type: "POST",
                url: "<%: AiGrow.Constants.VALIDATE_EMAIL %>",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: jsonText,
                async: false,
                success: function (msg) {
                    var jsonObj = JSON.parse(msg.d);
                    if (String(jsonObj["success"]).bool() && String(jsonObj["message"]).bool()) {
                        args.IsValid = false;
                    } else {
                        args.IsValid = true;
                    }
                },
                error: function (msg) {
                    console.log(msg.d);
                }
            });
        }
    </script>
</body>

</html>
