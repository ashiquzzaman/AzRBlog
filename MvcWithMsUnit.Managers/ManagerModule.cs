using Autofac;
using System.Reflection;

namespace MvcWithMsUnit.Managers
{
    public class ManagerModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(Assembly.Load("MvcWithMsUnit.Managers"))
                // .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()

                .InstancePerLifetimeScope();

        }

    }
}
