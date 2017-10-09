<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="codeRR.Client.AspNet.Demo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sample page</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>
            Welcome!
        </h1>
        <asp:Button runat="server" id="btnError" Text="Press for error" OnClick="btnError_Click" />
    </form>
</body>
</html>
