using System.Web.Http.Controllers;
using DnnExtendedFilter.Filters.Common;
using DotNetNuke.Web.Api;

namespace DnnExtendedFilter.Filters
{
    public class CustomModuleAuthorizeAttribute : DnnModuleAuthorizeAttribute
    {
        protected override bool SkipAuthorization(HttpActionContext actionContext)
        {
            return JwtAuthHelper.IsAuthenticatedJwtRequest(actionContext) || base.SkipAuthorization(actionContext);
        }
    }
}
 