using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace RelCustomPage
{
    public class Global : HttpApplication
    {
        void Application_Start()
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(WebApiConfig.RegisterContainer);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            GlobalConfiguration.Configure(WebApiConfig.SetupMiniProfiler);
        }
    }
}