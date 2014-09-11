using Interfaces;
using Microsoft.AspNet.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRServer
{
    /// <summary>
    /// This is the server hub implementation. This class is derived from Hub and is typed with the 
    /// IPlanningGridClient interface. So we can use IntelliType and Code Completion in this hub.
    /// </summary>
    public class PlanningGridHub : Hub<IPlanningGridClient>
    {
        /// <summary>
        /// This method is called when a client connects. Connection is logged to the console windows including
        /// the connection id of the new client.
        /// </summary>
        public override Task OnConnected()
        {
            Console.WriteLine("[{0}] Client '{1}' connected.", DateTime.Now.ToString("dd-mm-yyyy hh:MM:ss"), Context.ConnectionId);

            return base.OnConnected();
        }

        /// <summary>
        /// This method is called when a client disconnects from the server. Disconnection is logged to 
        /// the console windows including the connection id of the client that goes away.
        /// </summary>
        public override Task OnDisconnected()
        {
            Console.WriteLine("[{0}] Client '{1}' disconnected.", DateTime.Now.ToString("dd-mm-yyyy hh:MM:ss"), Context.ConnectionId);

            return base.OnDisconnected();
        }

        /// <summary>
        /// This method is called when a client reconnects to the server. Reconnection is logged to 
        /// the console windows including the connection id of the client that returns.
        /// </summary>
        public override Task OnReconnected()
        {
            Console.WriteLine("[{0}] Client '{1}' reconnected.", DateTime.Now.ToString("dd-mm-yyyy hh:MM:ss"), Context.ConnectionId);

            return base.OnReconnected();
        }

        /// <summary>
        /// This is a hub method implementation that can be called from a client. We take some parameters and print them
        /// to the console. At the end, we call all clients and notify them that new values have been entered by one client.
        /// </summary>
        /// <param name="accountId">The id of the account for which the client send data.</param>
        /// <param name="values">Data for the account.</param>
        /// <returns>Indicates whether data arrived successfully or not (it's just a fake here to showcase return values).</returns>
        public bool SaveAccountData(string accountId, decimal[] values)
        {
            if (values == null || values.Count() != 12)
                throw new ArgumentException("Parameter 'values' must contain 12 month values.");

            Console.WriteLine("\n[{0}] SignalR server method 'SaveAccountData' has been called by client '{1}':", DateTime.Now.ToString("dd-mm-yyyy hh:MM:ss"), Context.ConnectionId);
            Console.WriteLine("\tAccountId: {0};\n\tValues: {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}",
                accountId, values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7], values[8], values[9], values[10], values[11]);

            // Call all clients and notify them with the new data.
            Clients.All.AccountDataChanged(accountId, values);

            // Return a value to demonstrate return values.
            return true;
        }
    }
}
