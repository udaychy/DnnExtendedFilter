using System;
using System.Web.Http.Controllers;
using DnnExtendedFilter.Filters.Common;
using DotNetNuke.Web.Api;

namespace DnnExtendedFilter.Filters
{
    public class CustomValidateAntiForgeryTokenAttribute : ValidateAntiForgeryTokenAttribute
    {
        protected override Tuple<bool, string> IsAuthorized(HttpActionContext actionContext)
        {
            try
            {
                return JwtAuthHelper.IsAuthenticatedJwtRequest(actionContext) 
                    ? new Tuple<bool, string>(true, string.Empty) 
                    : base.IsAuthorized(actionContext);
            }
            catch (Exception e)
            {
                return new Tuple<bool, string>(false, e.Message);
            }
        }

    }
}
