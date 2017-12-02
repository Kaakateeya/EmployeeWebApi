using System;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace WebapiApplication.Api
{
    public class BindJson : System.Web.Http.Filters.ActionFilterAttribute
    {
        private Type _type;
        private string _queryStringKey;

        public BindJson(Type type, string queryStringKey)
        {
            _type = type;
            _queryStringKey = queryStringKey;
        }

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var json = actionContext.Request.RequestUri.ParseQueryString()[_queryStringKey];
            var serializer = new JavaScriptSerializer();
            actionContext.ActionArguments[_queryStringKey] = serializer.Deserialize(json, _type);
        }
    }
}