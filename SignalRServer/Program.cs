using Microsoft.Owin.Hosting;
using System;

namespace SignalRServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********************************************************************");
            Console.WriteLine("*                                                                  *");
            Console.WriteLine("*                              SERVER                              *");
            Console.WriteLine("*                                                                  *");
            Console.WriteLine("********************************************************************");

            var url = "http://localhost:8082";

            using (WebApp.Start(url))
            {
                Console.WriteLine("\n[{0}] SignalR server listening on {1}.", DateTime.Now.ToString("dd-mm-yyyy hh:MM:ss"), url);
                Console.ReadKey();
            }
        }
    }
}
