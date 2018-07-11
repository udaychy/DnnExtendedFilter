using System;
using System.Threading;
using System.Web.Http.Controllers;
using DotNetNuke.Common;

namespace DnnExtendedFilter.Filters.Common
{
    public static class JwtAuthHelper
    {
        public static bool IsAuthenticated()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return (identity.AuthenticationType ?? String.Empty).ToUpper() == FilterConstants.AuthType.Jwt
                 && identity.IsAuthenticated;
        }

        public static bool RequestContainJwtHeader(HttpActionContext context)
        {
            Requires.NotNull("context", context);
            if(context.Request == null) return false;

            var auth = context.Request.Headers.Authorization;
            return auth != null && auth.Scheme.ToUpper() == FilterConstants.AuthScheme.Bearer;
        }

        public static bool IsAuthenticatedJwtRequest(HttpActionContext context)
        {
            return RequestContainJwtHeader(context) && IsAuthenticated();
        }
    }
}
