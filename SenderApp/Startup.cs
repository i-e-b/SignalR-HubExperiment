using Owin;

namespace SenderApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            if (app != null) app.MapSignalR();
        }
    }
}