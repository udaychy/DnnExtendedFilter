using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DnnExtendedFilter.Filters;
using DotNetNuke.Security;
using DotNetNuke.Web.Api;

namespace DnnExtendedFilter.Controller
{
    [JwtAuthorize]
    [CustomSupportedModules("ViewProfile")]
    [CustomModuleAuthorize(AccessLevel = SecurityAccessLevel.View)]
    public class TestController : DnnApiController
    {
        [CLSCompliant(true)]
        [HttpGet()]
        public HttpResponseMessage HelloWorld()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello World");
        }
    }
}
