using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using Coderr.Client.ContextCollections;
using Coderr.Client.Contracts;
using Coderr.Client.Reporters;

namespace Coderr.Client.AspNet.ContextProviders
{
    /// <summary>
    ///     assembles all HTTP headers from the request.
    /// </summary>
    /// <remarks>They will be added to a collection called <c>HttpHeaders</c>.</remarks>
    public class HttpHeadersProvider : IContextCollectionProvider
    {
        /// <summary>
        ///     Gets "HttpHeaders"
        /// </summary>
        public string Name => "HttpHeaders";


        /// <summary>
        ///     Collect information
        /// </summary>
        /// <param name="context">Context information provided by the class which reported the error.</param>
        /// <returns>
        ///     Collection. Items with multiple values are joined using <c>";;"</c>
        /// </returns>
        public ContextCollectionDTO Collect(IErrorReporterContext context)
        {
            if (HttpContext.Current == null)
                return null;

            var myHeaders = new Dictionary<string, string>();
            foreach (string header in HttpContext.Current.Request.Headers)
            {
                myHeaders[header] = HttpContext.Current.Request.Headers[header];
            }

            myHeaders["Url"] = HttpContext.Current.Request.Url.ToString();
            return new ContextCollectionDTO("HttpHeaders", myHeaders);
        }
    }
}