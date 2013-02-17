using Microsoft.AspNet.SignalR;

namespace SignalRSimpleChat
{
    public class AdvancedChatHub : Hub
    {
         public void SendMessage(ChatMessage message)
         {
             Clients.All.sendChatMessage(message);
         }
    }
}