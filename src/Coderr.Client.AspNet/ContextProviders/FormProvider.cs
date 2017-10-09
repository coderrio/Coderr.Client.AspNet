using System.Web;
using codeRR.Client.ContextProviders;
using codeRR.Client.Contracts;
using codeRR.Client.Reporters;

namespace codeRR.Client.AspNet.ContextProviders
{
    /// <summary>
    ///     Adds a HTTP request form collection.
    /// </summary>
    /// <remarks>The name of the collection is <c>HttpForm</c></remarks>
    public class FormProvider : IContextInfoProvider
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

            return new ContextCollectionDTO("HttpForm", HttpContext.Current.Request.Form);
        }
    }
}