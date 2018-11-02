using CILantro.Tools.WebAPI.Exceptions;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace CILantro.Tools.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Services.Replace(typeof(IExceptionHandler), new ApplicationExceptionHandler());
        }
    }
}