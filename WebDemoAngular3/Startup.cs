using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebDemoAngular3.Startup))]
namespace WebDemoAngular3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
