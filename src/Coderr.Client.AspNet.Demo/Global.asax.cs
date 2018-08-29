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
            var url = new Uri("http://localhost:50473/");
            Err.Configuration.Credentials(url, 
                "fc1ab5989af040afb782b69683fbf459", 
                "972a3489a1ba42858234742bbe41709a");

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