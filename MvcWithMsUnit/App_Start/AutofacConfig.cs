using Autofac;
using Autofac.Integration.Mvc;
using MvcWithMsUnit.Entities;
using MvcWithMsUnit.Managers;
using MvcWithMsUnit.Repositories;
using System.Web.Mvc;

namespace MvcWithMsUnit
{
    public class AutofacConfig
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();

            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ManagerModule());
            builder.RegisterModule(new EntityModule());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}