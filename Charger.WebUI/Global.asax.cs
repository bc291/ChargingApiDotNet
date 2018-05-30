using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Charger.Domm.Concrete;
using Newtonsoft.Json;

namespace Charger.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register); //nowe
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer<EFDbContext>(null);
        }

        protected void Application_BeginRequest()
        {
            if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
            {
                Response.Flush();
            }
        }
    }

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Formatters.Add(new BrowserJsonFormatter());
           // config.MessageHandlers.Add(new PreflightRequestsHandler());
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.EnableCors();
        }


    }

    public class BrowserJsonFormatter : JsonMediaTypeFormatter
    {
        public BrowserJsonFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            this.SerializerSettings.Formatting = Formatting.Indented;
        }

        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
            headers.ContentType = new MediaTypeHeaderValue("application/json");
        }
    }

    //public class PreflightRequestsHandler : DelegatingHandler
    //{
    //    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    //    {
    //        if (request.Headers.Contains("Origin") && request.Method.Method.Equals("OPTIONS"))
    //        {
    //            var response = new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
    //            // Define and add values to variables: origins, headers, methods (can be global)               
    //            response.Headers.Add("Access-Control-Allow-Headers", "accept, content-type");

    //            var tsc = new TaskCompletionSource<HttpResponseMessage>();
    //            tsc.SetResult(response);
    //            return tsc.Task;
    //        }
    //        return base.SendAsync(request, cancellationToken);
    //    }

    //}


}
