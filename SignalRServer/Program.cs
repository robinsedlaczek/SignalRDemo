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
                Console.WriteLine("SignalR server listening on {0}.", url);
                Console.ReadKey();
            }
        }
    }
}
