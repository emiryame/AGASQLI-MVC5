using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AGASQLI.Startup))]
namespace AGASQLI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
