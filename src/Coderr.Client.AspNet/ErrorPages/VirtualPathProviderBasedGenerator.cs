using System;
using System.Configuration;
using System.Web;
using System.Web.Hosting;

namespace codeRR.Client.AspNet.ErrorPages
{
    /// <summary>
    ///     Uses <see cref="VirtualPathProvider" /> to load error pages.
    /// </summary>
    public class VirtualPathProviderBasedGenerator : PageGeneratorBase
    {
        private readonly string _virtualPath;


        /// <summary>
        ///     Creates a new instance of <see cref="VirtualPathProviderBasedGenerator" />.
        /// </summary>
        /// <param name="virtualPath">Path to the folder that contains the error pages, like <c>"~/Errors/"</c></param>
        public VirtualPathProviderBasedGenerator(string virtualPath)
        {
            if (virtualPath == null) throw new ArgumentNullException("virtualPath");
            _virtualPath = virtualPath;
        }

        /// <summary>
        ///     Generate HTML document
        /// </summary>
        /// <param name="context">context information which can be used while deciding which page to generate</param>
        protected override void GenerateHtml(PageGeneratorContext context)
        {
            var html = PageBuilder.Build(_virtualPath, context.ReporterContext);
            if (!html.ToLower().Contains("<form")
                &&
                (Err.Configuration.UserInteraction.AskUserForDetails ||
                 Err.Configuration.UserInteraction.AskUserForPermission))
                throw new ConfigurationErrorsException(
                    "You have to have a <form method=\"post\" action=\"http://yourwebsite/coderr/'\"> in your error page if you would like to collect error information.\r\n(Or set Err.Configuration.AskUserForPermission and Err.Configuration.AskUserForDetails to false)");
            if (!html.Contains("$reportId$"))
                throw new ConfigurationErrorsException(
                    "You have to have a '<input type=\"hidden\" name=\"reportId\" value=\"$reportId$\" />' tag in your HTML. The '$reportId$' will be replaced with the correct report id upon errors by this library.");

            html = html.Replace("$reportId$", context.ReportId)
                .Replace("$URL$", VirtualPathUtility.ToAbsolute("~/coderr/Submit/"));

            if (!Err.Configuration.UserInteraction.AskUserForPermission &&
                (Err.Configuration.UserInteraction.AskForEmailAddress ||
                 Err.Configuration.UserInteraction.AskUserForDetails))
                html = html.Replace("$AllowReportUploading$", "checked");
            else
                html = html.Replace("$AllowReportUploading$", "");

            context.SendResponse("text/html", html);
        }
    }
}