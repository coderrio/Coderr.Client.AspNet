<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Coderr.Client.AspNet.Demo.Errors.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form action="$URL$" method="post">
        <input type="hidden" name="reportId" value="$reportId$" />
        <div>
            <h1>General error!</h1>
            <p>this is just a sample of custom error pages.</p>
            <p>You can create your own, or uncomment <code>Err.Configuration.SetErrorPageGenerator</code> in global.asax to view the built in ones.</p>
            <textarea name="Description"></textarea>
            <input type="email" name="email" placeholder="Email"/>
            <input type="checkbox" name="Allowed" value="true" checked="$AllowReportUploading$" />
            I allow thy to collect the additional information.
            <input type="submit" value="SEND"/>
        </div>
    </form>
</body>
</html>
