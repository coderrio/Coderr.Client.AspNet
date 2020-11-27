using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Web;
using Coderr.Client.ContextCollections;
using Coderr.Client.Contracts;
using Coderr.Client.Reporters;

namespace Coderr.Client.AspNet.ContextProviders
{
    /// <summary>
    ///     Adds a HTTP request query string collection (<c>"HttpSession"</c>)
    /// </summary>
    /// <remarks>
    ///     <para>The name of the collection is <c>HttpSession</c>.</para>
    ///     <para>Session objects are serialized as JSON, strings are added as-is.</para>
    /// </remarks>
    public class SessionProvider : IContextCollectionProvider
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
            var items = new Dictionary<string, string>();
            foreach (string key in HttpContext.Current.Session.Keys)
            {
                var value = HttpContext.Current.Session[key];
                switch (value)
                {
                    case string _:
                        converter.ConvertToDictionary(key, value, items);
                        break;
                    case IEnumerable _:
                        converter.ConvertToDictionary($"{key}.", value, items);
                        break;
                    default:
                        converter.ConvertToDictionary(key, value, items);
                        break;
                }
            }

            return new ContextCollectionDTO(Name, items);
        }
    }
}