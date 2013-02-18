using System;
using Microsoft.AspNet.SignalR;

namespace SignalRSimpleChat
{
    public class ChatHub : Hub
    {
        public void Send(string message)
        {
            Clients.All.sendMessage(message);
        }

        public void OnlyToMe(string message)
        {
            Clients.Caller.sendMessage(message);
        }

        public void ToEveryoneElse(string message)
        {
            Clients.Others.sendMessage(message);
        }

        public void SendServerTime(DateTime serverTime)
        {
            var message = string.Format("Klokken er {0} den {1}", serverTime.ToString("HH:mm:ss"),
                                        serverTime.ToString("dd.MM.yyyy"));

            Clients.All.sendServerTime(message);
        }
    }
}