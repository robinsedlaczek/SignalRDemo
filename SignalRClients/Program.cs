using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRClients
{
    class Program
    {
        static void Main(string[] args)
        {
            SavePlanningData();

            /// For events:
            //var eventName = ;
            //proxy.Subscribe(eventName);
            //proxy.InvokeEvent(eventName, args);


            //Handle incoming event from server: use Invoke to write to console from SignalR's thread 
            //HubProxy.On<string, string>("AddMessage", (name, message) => 
            //    Dispatcher.Invoke(() => 
            //    {
            //        RichTextBoxConsole.AppendText(String.Format("{0}: {1}\r", name, message)) 
            //    ));

            Console.WriteLine("Press key to exit.");
            Console.ReadKey();
        }

        private static async Task SavePlanningData()
        {
            var hubConnection = new HubConnection("http://localhost:8080");
            var hubProxy = hubConnection.CreateHubProxy("PlanningGridHub");

            await hubConnection.Start();

            var accountId = "231245050";
            var values = new decimal[] { 0.1M, 0.2M, 0.3M, 0.4M, 0.5M, 0.6M, 0.7M, 0.8M, 0.9M, 1.0M, 1.1M, 1.2M };

            await hubProxy.Invoke("SaveAccountData", accountId, values);
        }
    }
}
