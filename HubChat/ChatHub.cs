using Microsoft.AspNetCore.SignalR;
namespace HRSystem.HubChat
{
    public class ChatHub:Hub
    {
        public void SendMessage(string UserName,String Message)
        {
            Clients.AllExcept(Context.ConnectionId).SendAsync("RecieveMessage", Context.User, Message);
        }
    }
}
