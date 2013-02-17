using Microsoft.AspNet.SignalR;

namespace SignalRSimpleChat
{
    public class ChatHub : Hub
    {
         public void Send(string message)
         {
             Clients.All.sendMessage(message);
         }
    }
}