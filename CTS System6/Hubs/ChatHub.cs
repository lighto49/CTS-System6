using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message, string RoomId)
        {
            //await Clients.All.SendAsync("ReceiveMessage", user, message);
            await Clients.Group(RoomId).SendAsync("ReceiveMessage", user, message);
        }
        public async Task JoinRoom(string RoomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, RoomId);
        }
    }
}
