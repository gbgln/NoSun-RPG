using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NoSun.Startup))]
namespace NoSun
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
