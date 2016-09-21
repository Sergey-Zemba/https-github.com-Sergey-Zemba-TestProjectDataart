using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewsApp.WEB.Startup))]
namespace NewsApp.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
