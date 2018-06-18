using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CILantroTestManager.Startup))]
namespace CILantroTestManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}