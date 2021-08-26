using RelCustomPage.App_Start;
using StackExchange.Profiling;
using StackExchange.Profiling.SqlFormatters;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace RelCustomPage
{
    public static class WebApiConfig
    {
        public class SqlFormmater : ISqlFormatter
        {
            public string FormatSql(string commandText, List<SqlTimingParameter> parameters)
            {
                var buffer = new StringBuilder();

                if (parameters?.Any() ?? false)
                {
                    buffer.Append("Declare ");
                    var values = string.Join(",        \n", parameters);
                    buffer.Append(values);
                }
                buffer.AppendLine();
                buffer.AppendLine();
                buffer.Append(commandText);

                return buffer.ToString();
            }
        }
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
        public static void SetupMiniProfiler(HttpConfiguration config)
        {
#if DEBUG

            config.Filters.Add(new ProfilingActionFilter());
            config.Filters.Add(new SimpleInjectorActionFilter());
#endif
        }
        public static void RegisterContainer(HttpConfiguration config)
        {
            var container = config.ConfigureContainer();
        }
    }
}
