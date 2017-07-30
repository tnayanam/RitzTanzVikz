using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bridge.Startup))]
namespace Bridge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
