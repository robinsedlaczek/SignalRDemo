using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRServer
{
    public class PlanningGridHub : Hub
    {
        public override Task OnConnected()
        {
            Console.WriteLine("Client connected.");

            return base.OnConnected();
        }

        public override Task OnDisconnected()
        {
            Console.WriteLine("Client disconnected.");

            return base.OnDisconnected();
        }

        public override Task OnReconnected()
        {
            Console.WriteLine("Client reconnected.");

            return base.OnReconnected();
        }

        public void SaveAccountData(string accountId, decimal[] values)
        {
            if (values == null || values.Count() != 12)
                throw new ArgumentException("Parameter 'values' must contain 12 month values.");

            Console.WriteLine("SignalR server method 'SaveAccountData' has been called.");

            // Clients.All.???

        }
    }
}
