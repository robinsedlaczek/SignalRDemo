using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://localhost:8080";

            using (WebApp.Start(url))
            {
                Console.WriteLine("[{0}] SignalR server listening on {1}.", DateTime.Now.ToString("dd-mm-yyyy hh:MM:ss"), url);
                Console.ReadKey();
            }
        }
    }
}
