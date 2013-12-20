using System.Threading.Tasks;
using Common;
using Microsoft.AspNet.SignalR;

namespace SignalrSqlSender
{
    public class MessageHub : Hub
    {
        public void Send(string message)
        {
            Clients.All.addMessage(message);
        }

        public void Reply(string message)
        {
            StatusMessage.Write("Got a reply: " + message + ", from " + Context.ConnectionId);

            CallerOnThisHub().Send("I got your " + message + ", " + Context.ConnectionId);
        }

        private dynamic CallerOnThisHub()
        {
            return GlobalHost.ConnectionManager.GetHubContext<MessageHub>().Clients.Client(Context.ConnectionId);
        }

        public override Task OnConnected()
        {
            StatusMessage.Write("Client connected");
            return base.OnConnected();
        }

        public override Task OnDisconnected()
        {
            StatusMessage.Write("Client disconnected");
            return base.OnDisconnected();
        }
    }
}