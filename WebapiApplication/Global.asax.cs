using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using WebapiApplication;
using WebapiApplication.App_Start;
using System.Web.Http;
using KaakateeyaDAL;
using System.Data.SqlClient;

namespace WebapiApplication
{
    public class Global : HttpApplication
    {
        public void Application_Start(object sender, EventArgs e)
        {          
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            SqlConnection.ClearAllPools();
        }
        public void Application_End(object sender, EventArgs e) { }
        public void Application_Error(object sender, EventArgs e) {  }
        public void Application_BeginRequest(object sender, EventArgs e)
        {
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache");
                //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
                //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");

                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
                // SQLHelper.GetSQLConnection().Close();
                // SqlConnection.ClearAllPools();
                // Dispose();
            }
        }
    }
}
