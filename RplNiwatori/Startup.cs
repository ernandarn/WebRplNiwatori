using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RplNiwatori.Startup))]
namespace RplNiwatori
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
