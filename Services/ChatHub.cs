using Microsoft.AspNetCore.SignalR;

namespace dotnet_realtime_chat.Services;

    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
