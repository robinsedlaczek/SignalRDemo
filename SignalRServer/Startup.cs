using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalRServer.Startup))]

namespace SignalRServer
{
    /// <summary>
    /// The OWIN startup class. Here we configure the server pipeline.
    /// </summary>
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Add SignalR to the server pipeline.
            app.MapSignalR();
        }
    }
}

