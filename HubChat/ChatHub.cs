//using Microsoft.AspNetCore.SignalR;
namespace HRSystem.HubChat
{
    public class ChatHub : Hub
    {
        
        //public Dictionary<string, string> ConnectionIDs = new Dictionary<string, string>();
        public override Task OnConnectedAsync()
        {
            //ConnectionIDs[Context.User.Identity.Name] = Context.ConnectionId;
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(System.Exception? exception)
        {
            //ConnectionIDs.Remove(Context.User.Identity.Name);
            return base.OnDisconnectedAsync(exception);
        }
        public void SendMessage(string userId, String Message)
        {
            Clients.User(userId).SendAsync("RecieveMessage",Message);
            //string selectedUserId = ConnectionIDs[selectedUser];
            //Clients.All.SendAsync("RecieveMessage", userId, Message);
        }

        //public int getStatus(string UserName)
        //{
        //    if (ConnectionIDs.Any(c => c.Key == UserName))
        //        return 1;
        //    return 0;
        //}

    }

}

