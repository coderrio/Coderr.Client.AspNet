using System.Web;
using Coderr.Client.ContextProviders;
using Coderr.Client.Contracts;
using Coderr.Client.Reporters;

namespace Coderr.Client.AspNet.ContextProviders
{
    /// <summary>
    ///     Adds a HTTP request query string collection.
    /// </summary>
    /// <remarks>The name of the collection is <c>HttpQueryString</c></remarks>
    public class QueryStringProvider : IContextInfoProvider
    {
        /// <summary>
        ///     Gets "HttpQueryString"
        /// </summary>
        public string Name => "HttpQueryString";


        /// <summary>
        ///     Collect information
        /// </summary>
        /// <param name="context"></param>
        /// <returns>Collection</returns>
        public ContextCollectionDTO Collect(IErrorReporterContext context)
        {
            if (HttpContext.Current == null || HttpContext.Current.Request.QueryString.Count == 0)
                return null;

            return new ContextCollectionDTO("HttpQueryString", HttpContext.Current.Request.QueryString);
        }
    }
}