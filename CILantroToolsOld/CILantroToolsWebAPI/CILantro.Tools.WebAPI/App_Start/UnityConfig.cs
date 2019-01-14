using CILantro.Tools.WebAPI.Database;
using Unity;
using Unity.Lifetime;

namespace CILantro.Tools.WebAPI.App_Start
{
    public static class UnityConfig
    {
        public static IUnityContainer GetConfiguredContainer()
        {
            return new UnityContainer();
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ApplicationDbContext>(new HierarchicalLifetimeManager());
        }
    }
}