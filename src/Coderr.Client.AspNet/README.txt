codeRR ASP.NET package
=====================

Welcome to codeRR! 

We try to answer questions as fast as we can at our forum: http://discuss.coderrapp.com. 
If you have any trouble at all, don't hesitate to post a message there.

This library is the client library of codeRR. What it does is to report exceptions to codeRR.

However, this library do not process the information but require a codeRR server for that.
You can either install the open source server from https://github.com/coderrapp/coderr.server, or
use our hosted service at https://coderrapp.com/live.


Configuration
=============

To start with, you need to configure the connection to the codeRR server, 
this code is typically added in your Global.asax. This information is found either
in our hosted service or in your installed codeRR server.

    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //replace with your server URL and your appkey/SharedSecret.
            var uri = new Uri("http://localhost/OneTrueError/");
            Err.Configuration.Credentials(uri,
                "5f219f356daa40b3b31dfc67514df6d6",
                "22612e4444f347d1bb3d841d64c9750a");


            Err.Configuration.CatchAspNetExceptions();
        }
    }

There are more configuration options available:
https://coderrapp.com/documentation/client/libraries/aspnet/


Reporting exceptions
====================

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

Questions? http://discuss.coderrapp.com
Documentation: https://coderrapp.com/documentation/client/libraries/aspnet/


