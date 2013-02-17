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
    }
}