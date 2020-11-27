using System.Collections.Generic;
using System.Web;
using Coderr.Client.ContextCollections;
using Coderr.Client.Contracts;
using Coderr.Client.Reporters;

namespace Coderr.Client.AspNet.ContextProviders
{
    /// <summary>
    ///     Adds a HTTP request form collection.
    /// </summary>
    /// <remarks>The name of the collection is <c>HttpForm</c></remarks>
    public class FormProvider : IContextCollectionProvider
    {
        /// <summary>
        ///     Gets "HttpForm"
        /// </summary>
        public string Name => "HttpForm";


        /// <summary>
        ///     Collect information
        /// </summary>
        /// <param name="context"></param>
        /// <returns>Collection</returns>
        public ContextCollectionDTO Collect(IErrorReporterContext context)
        {
            if (HttpContext.Current == null || HttpContext.Current.Request.Form.Count == 0)
                return null;

            var myItems = new Dictionary<string, string>();
            foreach (string header in HttpContext.Current.Request.Form)
            {
                myItems[header] = HttpContext.Current.Request.Form[header];
            }

            return new ContextCollectionDTO("HttpForm", myItems);
        }
    }
}