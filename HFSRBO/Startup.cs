using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HFSRBO.Startup))]
namespace HFSRBO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
