<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="AiGrow.Portal.Logout" %>
<%%>
<!DOCTYPE html>

<% 
    //Calls the logout method which removes the current session.
    //Redirects to a relevant chargenet.lk page which displays a message.
    //The relevant chargenet.lk page needs to be implemented on WordPress.
    AiGrow.SessionHandler.logout();
    
    Response.Redirect(AiGrow.Constants.LOGIN_URL + "?message=" + AiGrow.Classes.Messages.logoutSuccess + "&token=" + AiGrow.Encryption.createSHA1(AiGrow.Classes.Messages.logoutSuccess));

%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
