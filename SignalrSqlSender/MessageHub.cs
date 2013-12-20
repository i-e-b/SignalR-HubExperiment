using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace SignalrSqlSender
{
    public class MessageHub : Hub
    {
        public void Send(string message)
        {
            Clients.All.addMessage(message);
        }
        public override Task OnConnected()
        {
            Console.WriteLine("Client connected");

            return base.OnConnected();
        }

        public override Task OnDisconnected()
        {
            Console.WriteLine("Client disconnected");

            return base.OnDisconnected();
        }
    }
}