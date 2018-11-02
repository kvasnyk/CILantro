using CILantro.Tools.WebAPI.App_Start;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http;
using Unity.AspNet.WebApi;

[assembly: OwinStartup(typeof(CILantro.Tools.WebAPI.Startup))]
namespace CILantro.Tools.WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var httpConfig = new HttpConfiguration();

            ConfigureUnity(httpConfig);
            ConfigureCors(app);

            WebApiConfig.Register(httpConfig);
            app.UseWebApi(httpConfig);
        }

        private void ConfigureUnity(HttpConfiguration httpConfig)
        {
            var unityContainer = UnityConfig.GetConfiguredContainer();
            UnityConfig.RegisterTypes(unityContainer);

            httpConfig.DependencyResolver = new UnityHierarchicalDependencyResolver(unityContainer);
        }

        private void ConfigureCors(IAppBuilder app)
        {
            var corsPolicy = new CorsPolicy
            {
                AllowAnyHeader = true,
                AllowAnyMethod = true,
                AllowAnyOrigin = true
            };

            var corsOptions = new CorsOptions
            {
                PolicyProvider = new CorsPolicyProvider
                {
                    PolicyResolver = context => Task.FromResult(corsPolicy)
                }
            };

            app.UseCors(corsOptions);
        }
    }
}