using System.Web;
using codeRR.Client.ContextProviders;
using codeRR.Client.Contracts;
using codeRR.Client.Converters;
using codeRR.Client.Reporters;

namespace codeRR.Client.AspNet.ContextProviders
{
    /// <summary>
    ///     Adds a HTTP request query string collection (<c>"HttpSession"</c>)
    /// </summary>
    /// <remarks>
    ///     <para>The name of the collection is <c>HttpSession</c>.</para>
    ///     <para>Session objects are serialized as JSON, strings are added as-is.</para>
    /// </remarks>
    public class SessionProvider : IContextInfoProvider
    {
        /// <summary>
        ///     Gets "HttpSession"
        /// </summary>
        public string Name => "HttpSession";

        /// <summary>
        ///     Collect information
        /// </summary>
        /// <param name="context"></param>
        /// <returns>Collection</returns>
        public ContextCollectionDTO Collect(IErrorReporterContext context)
        {
            if (HttpContext.Current.Session == null || HttpContext.Current.Session.Count == 0)
                return null;

            var converter = new ObjectToContextCollectionConverter();
            return converter.Convert("HttpSession", HttpContext.Current.Session);
        }
    }
}