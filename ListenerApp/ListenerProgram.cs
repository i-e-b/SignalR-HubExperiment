using System;
using System.Configuration;
using System.Threading;
using Common;
using Microsoft.AspNet.SignalR.Client;

namespace ListenerApp
{
    class ListenerProgram
    {
        private static HubConnection _conn;
        private static IHubProxy _proxy;

        static void Main()
        {
            Console.WriteLine("Message LISTENER");
            Console.WriteLine("Starting up...");
            Thread.Sleep(2000);
            var endpoint = ConfigurationManager.AppSettings["ServerHost"];

            var conn = OwinHostedListener(endpoint);

            Console.WriteLine("Listening. Press enter to exit");
            Console.ReadLine();
            Console.WriteLine("Shutting down. Please wait");
            conn.Stop();
        }

        static HubConnection OwinHostedListener(string endpoint)
        {
            _conn = new HubConnection(endpoint);

            _conn.StateChanged += conn_StateChanged;

            _proxy = _conn.CreateHubProxy("MessageHub");
            _proxy.On<string>("Send", ShowMessage);
            _proxy.On<string>("Reply", ShowReply);

            _conn.Start();
            return _conn;
        }

        static void conn_StateChanged(StateChange obj)
        {
            switch (obj.NewState)
            {
                case ConnectionState.Connected:
                    StatusMessage.Write("Connected");
                    break;
                case ConnectionState.Reconnecting:
                    StatusMessage.Write("Lost connection");
                    break;
            }
        }

        private static void ShowMessage(string message)
        {
            if (message.StartsWith("ping"))
            {
                Console.WriteLine("server said \"ping\", I will send \"pong\"");
                _proxy.Invoke("Reply", "pong");
            }
            else
            {
                Console.WriteLine("server said \"" + message + "\"");
            }
        }
        private static void ShowReply(string message)
        {
            Console.WriteLine("server replied directly to us: \"" + message + "\"");
        }
    }
}
