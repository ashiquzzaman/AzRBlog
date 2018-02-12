using Autofac;
using System.Reflection;

namespace MvcWithMsUnit.Repositories
{

    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("MvcWithMsUnit.Repositories"))
                //.Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
