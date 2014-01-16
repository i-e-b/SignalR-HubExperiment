using System;
using System.Configuration;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;

namespace SenderApp
{
    class SenderProgram
    {
        static void Main()
        {
            Console.WriteLine("Message SENDER");
            var endpoint = ConfigurationManager.AppSettings["ServerHost"];

            OwinHostedSender(endpoint);
        }

        static void OwinHostedSender(string endpoint)
        {
            Console.WriteLine("Starting up...");
            using (WebApp.Start<Startup>(endpoint))
            {
                Console.WriteLine("Server running at " + endpoint);
                string line;

                var ctx = GlobalHost.ConnectionManager.GetHubContext<MessageHub>();


                Console.WriteLine("Write messages (blank line to exit)");
                while ((line = Console.ReadLine()) != "")
                {
                    ctx.Clients.All.Send(line);
                }
            }
        }
    }
}
