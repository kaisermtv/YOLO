using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OTOHATINHV2.Startup))]
namespace OTOHATINHV2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
