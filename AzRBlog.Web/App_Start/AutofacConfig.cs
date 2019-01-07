using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using AzRBlog.Entities;

namespace AzRBlog.Web
{
    public class AutofacConfig
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
            builder.RegisterType(typeof(ApplicationDbContext)).As(typeof(DbContext)).InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.Load("AzRBlog.Repositories"))
                //.Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.Load("AzRBlog.Services"))
                // .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}