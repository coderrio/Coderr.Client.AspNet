using System;
using codeRR.Client.AspNet.ErrorPages;

namespace codeRR.Client.AspNet.Demo
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //replace with your server URL and your appkey/SharedSecret.
            var uri = new Uri("http://localhost/OneTrueError/");
            Err.Configuration.Credentials(uri,
                "5f219f356daa40b3b31dfc67514df6d6",
                "22612e4444f347d1bb3d841d64c9750a");

            //Err.Configuration.SetErrorPageGenerator(new VirtualPathProviderBasedGenerator("~/Errors/"));
            Err.Configuration.CatchAspNetExceptions();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}