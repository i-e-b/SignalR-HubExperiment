using System.Configuration;
using Microsoft.AspNet.SignalR;
using Owin;

namespace ListenerApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalHost.DependencyResolver.UseSqlServer(ConfigurationManager.ConnectionStrings["SignalRBackplane"].ConnectionString);
            app.MapSignalR();
        }
    }
}