using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(iiii.Startup))]
namespace iiii
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
