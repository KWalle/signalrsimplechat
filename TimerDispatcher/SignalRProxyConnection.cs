using System;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;

namespace TimerDispatcher
{
    public class SignalRProxyConnection
    {
        private static bool connected;
        private static IHubProxy proxy;
        private static HubConnection hubConnection;
        private static string connectionUrl = "http://localhost:50308/";

        public static void SendServerTime(DateTime serverTime)
        {
            if (!connected)
            {
                Connect();
            }

            if (hubConnection.State == ConnectionState.Connected)
                proxy.Invoke("SendServerTime", serverTime);
        }

        private static void Connect()
        {
            hubConnection = new HubConnection(connectionUrl);
            proxy = hubConnection.CreateHubProxy("chatHub");
            hubConnection.Start().Wait();
            connected = true;
        }
    }
}