using Owin;

namespace SignalrSqlSender
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            if (app != null) app.MapSignalR();
        }
    }
}