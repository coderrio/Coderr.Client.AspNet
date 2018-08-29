using System;
using System.IO;
using System.Web;

namespace Coderr.Client.AspNet.Demo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Complex"] = new {UserName = "Arne", Age = 92};
            Request.Cookies.Add(new HttpCookie("milk", "sour") {Expires = DateTime.Today.AddDays(30)});
        }


        protected void btnError_Click(object sender, EventArgs e)
        {
			// Press F5 if Visual Studio breaks here ("First chance exceptions")
            throw new InvalidDataException("Lore was found.");
        }
    }
}