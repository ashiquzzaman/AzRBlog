using Autofac;
using System.Data.Entity;

namespace MvcWithMsUnit.Entities
{

    public class EntityModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterModule(new RepositoryModule());

            builder.RegisterType(typeof(ApplicationDbContext)).As(typeof(DbContext)).InstancePerLifetimeScope();

        }

    }
}
