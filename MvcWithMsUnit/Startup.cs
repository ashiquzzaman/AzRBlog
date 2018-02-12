using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcWithMsUnit.Startup))]
namespace MvcWithMsUnit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
