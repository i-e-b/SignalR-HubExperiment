using System.Configuration;
using Microsoft.AspNet.SignalR;
using Owin;

namespace SignalrSqlSender
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalHost.DependencyResolver.UseSqlServer(ConfigurationManager.ConnectionStrings["SignalRBackplane"].ConnectionString);
            if (app != null) app.MapSignalR();
        }
    }
}