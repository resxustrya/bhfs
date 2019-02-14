using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HFSRBO.Client.Startup))]
namespace HFSRBO.Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
