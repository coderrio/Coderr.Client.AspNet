using System;
using Coderr.Client;
using Coderr.Client.AspNet.ErrorPages;

namespace Coderr.Client.AspNet.Demo
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //replace with your server URL and your appkey/SharedSecret.
            var url = new Uri("http://localhost:60473/");
            Err.Configuration.Credentials(url,
                "5a617e0773b94284bef33940e4bc8384",
                "3fab63fb846c4dd289f67b0b3340fefc");


            Err.Configuration.SetErrorPageGenerator(new VirtualPathProviderBasedGenerator("~/Errors/"));
            Err.Configuration.UserInteraction.AskUserForPermission = true;
            Err.Configuration.UserInteraction.AskForEmailAddress = true;
            Err.Configuration.UserInteraction.AskUserForDetails = true;
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