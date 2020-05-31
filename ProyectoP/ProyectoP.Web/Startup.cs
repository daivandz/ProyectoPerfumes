using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoP.Web.Startup))]
namespace ProyectoP.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
