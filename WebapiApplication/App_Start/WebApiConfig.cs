using System.Web.Http;

namespace WebapiApplication.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
           name: "DefaultApi",
                //name: "ReportingApi",
        routeTemplate: "api/{controller}/{action}/{id}",
        defaults: new { id = RouteParameter.Optional }
               );
        }
    }
}