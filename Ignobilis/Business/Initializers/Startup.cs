using Ignobilis.Business.Initializers;
using Microsoft.Owin;
using Owin;
[assembly: OwinStartup(typeof(Startup))]

namespace Ignobilis.Business.Initializers
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}