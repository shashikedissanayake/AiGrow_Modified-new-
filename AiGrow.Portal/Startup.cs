using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AiGrow.Portal.Startup))]
namespace AiGrow.Portal
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
