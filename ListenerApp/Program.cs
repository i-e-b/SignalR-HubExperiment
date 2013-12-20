using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.Owin.Hosting;

namespace ListenerApp
{
    class Program
    {

        static void Main()
        {
            Console.WriteLine("Message listener over SQL backplane");
            Console.WriteLine("Starting up...");
            Thread.Sleep(1000);
            var endpoint = ConfigurationManager.AppSettings["ServerHost"];

            var conn = OwinHostedListener(endpoint);

            Console.WriteLine("Listening. Press enter to exit");
            Console.ReadLine();

            conn.Stop();
        }

        static HubConnection OwinHostedListener(string endpoint)
        {
            var conn = new HubConnection(endpoint);

            conn.StateChanged += conn_StateChanged;

            var proxy = conn.CreateHubProxy("MessageHub");

            conn.Received += conn_Received;
            proxy.On<string>("Send", ShowMessage);
            proxy.Subscribe("Send").Received += Program_Received;

            conn.Start();
            return conn;
        }

        static void conn_StateChanged(StateChange obj)
        {
            Console.WriteLine("New state: " + obj.NewState);
        }

        static void conn_Received(string obj)
        {
            Console.WriteLine("conn received: "+obj);
        }

        static void Program_Received(System.Collections.Generic.IList<Newtonsoft.Json.Linq.JToken> obj)
        {
            Console.WriteLine("received?");
        }

        private static void ShowMessage(string message)
        {
            Console.WriteLine("server said \"" + message + "\"");
        }
    }
}
