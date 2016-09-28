using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppExample.Startup))]
namespace WebAppExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
