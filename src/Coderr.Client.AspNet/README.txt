Coderr ASP.NET package
======================

This is an automation library for Coderr in ASP.NET applications.
You also need a Coderr Server.

Getting started help:
https://coderr.io/documentation/getting-started/

ASP.NET configuration:
https://coderr.io/documentation/client/libraries/aspnet/


Alternative packages:

* Coderr.Client.AspNet.Mvc5 - Better integration for ASP.NET MVC5 applications
* Coderr.Client.AspNet.WebApi2 - Better integration for ASP.NET WebApi 2.x applications
* Coderr.Client.AspNetCore.Mvc - Better integration for ASP.NET Core MVC applications


Quick start
===========

To start with, you need to configure the connection to the Coderr server, 
this code is typically added in your Global.asax. This information is found either
in our hosted service or in your installed Coderr server.

    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //replace with your server URL and your appkey/SharedSecret.
            var uri = new Uri("http://localhost/coderr/");
            Err.Configuration.Credentials(uri,
                "yourAppKey",
                "yourSharedSecret");


            Err.Configuration.CatchAspNetExceptions();
        }
    }




Reporting errors manually
=========================

This is one of many examples:

    public void SomeMethod(PostViewModel model)
    {
        try
        {
            _somService.Execute(model);
        }
        catch (Exception ex)
        {
            Err.Report(ex, model);

            //some custom handling
        }

        // some other code here...
    }


Questions:
https://discuss.coderr.io

Guides and support
https://coderr.io/guides-and-support/
