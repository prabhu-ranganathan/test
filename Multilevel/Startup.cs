using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Multilevel.Startup))]
namespace Multilevel
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
