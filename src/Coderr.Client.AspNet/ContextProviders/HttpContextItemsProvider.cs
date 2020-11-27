using System.Web;
using Coderr.Client.ContextCollections;
using Coderr.Client.Contracts;
using Coderr.Client.Reporters;

namespace Coderr.Client.AspNet.ContextProviders
{
    /// <summary>
    ///     Generates a collection named "HttpContextItems" consisting of <c>HttpContext.Current.Items</c>.
    /// </summary>
    public class HttpContextItemsProvider : IContextCollectionProvider
    {
        /// <summary>Collect information</summary>
        /// <param name="context">Context information provided by the class which reported the error.</param>
        /// <returns>Collection. Items with multiple values are joined using <c>";;"</c></returns>
        public ContextCollectionDTO Collect(IErrorReporterContext context)
        {
            if (HttpContext.Current.Items.Count == 0)
                return null;

            return HttpContext.Current.Items.ToContextCollection("HttpContextItems");
        }

        /// <summary>
        ///     HttpContextItems
        /// </summary>
        public string Name { get; private set; }
    }
}