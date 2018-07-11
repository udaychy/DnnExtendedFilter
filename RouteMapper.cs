using DotNetNuke.Web.Api;

namespace DnnExtendedFilter
{
    public class RouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute("DnnExtendedFilter", "default", "{controller}/{action}", new[] { "DnnExtendedFilter.Controller" });
        }
    }
}
