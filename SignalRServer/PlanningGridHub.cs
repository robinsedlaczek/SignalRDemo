using Microsoft.AspNet.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRServer
{
    public class PlanningGridHub : Hub
    {
        public override Task OnConnected()
        {
            Console.WriteLine("[{0}] Client connected.", DateTime.Now.ToString("dd-mm-yyyy hh:MM:ss"));

            return base.OnConnected();
        }

        public override Task OnDisconnected()
        {
            Console.WriteLine("[{0}] Client disconnected.", DateTime.Now.ToString("dd-mm-yyyy hh:MM:ss"));

            return base.OnDisconnected();
        }

        public override Task OnReconnected()
        {
            Console.WriteLine("[{0}] Client reconnected.", DateTime.Now.ToString("dd-mm-yyyy hh:MM:ss"));

            return base.OnReconnected();
        }

        public void SaveAccountData(string accountId, decimal[] values)
        {
            if (values == null || values.Count() != 12)
                throw new ArgumentException("Parameter 'values' must contain 12 month values.");

            Console.WriteLine("\n[{0}] SignalR server method 'SaveAccountData' has been called by client '{1}':", DateTime.Now.ToString("dd-mm-yyyy hh:MM:ss"), Context.ConnectionId);
            Console.WriteLine("\tAccountId: {0};\n\tValues: {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}",
                accountId, values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7], values[8], values[9], values[10], values[11]);

            Clients.All.AccountDataChanged(accountId, values);
        }
    }
}
