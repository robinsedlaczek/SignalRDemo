using Microsoft.AspNet.SignalR.Client;
using System;

namespace SignalRClients.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********************************************************************");
            Console.WriteLine("*                                                                  *");
            Console.WriteLine("*                              CLIENT                              *");
            Console.WriteLine("*                                                                  *");
            Console.WriteLine("********************************************************************");

            var connection = new HubConnection("http://localhost:8082/");
            var proxy = connection.CreateHubProxy("SaveAccountData");

            connection.Start();

            Console.WriteLine("\n\nPress ESC to exit.");

            char key = (char) 0;

            while (key != 27)
            {
                proxy.On<string, decimal[]>("AccountDataChanged", (accountId, values) =>
                {
                    Console.WriteLine("\tAccountId: {0};\n\tValues: {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}",
                        accountId, values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7], values[8], values[9], values[10], values[11]);
                });

                key = Console.ReadKey().KeyChar;
            }
        }

    }
}
