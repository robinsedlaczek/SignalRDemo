using Microsoft.Owin.Hosting;
using System;

namespace SignalRServer
{
    /// <summary>
    /// The program. This simple console application is used to run the SignalR server in a console. This is a  self-hosting scenario.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********************************************************************");
            Console.WriteLine("*                                                                  *");
            Console.WriteLine("*                              SERVER                              *");
            Console.WriteLine("*                                                                  *");
            Console.WriteLine("********************************************************************");

            // Define the URL where the server is available.
            var url = "http://localhost:8082";

            // Start the server that hosts the SignalR application.
            using (WebApp.Start(url))
            {
                Console.WriteLine("\n[{0}] SignalR server listening on {1}.", DateTime.Now.ToString("dd-mm-yyyy hh:MM:ss"), url);
                Console.ReadKey();
            }
        }
    }
}
