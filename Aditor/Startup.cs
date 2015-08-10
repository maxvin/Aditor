using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Aditor.Startup))]
namespace Aditor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
