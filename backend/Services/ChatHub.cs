using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace dotnet_realtime_chat.Services;

    [Authorize]
    public class ChatHub : Hub
    {

        public String? GetUsername()
        {
            return Context.User?.Identity?.Name ?? "Unknown";
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("UserJoined", $"{GetUsername()} joined.");
            
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.All.SendAsync("UserLeft", $"{GetUsername()} disconnected.");

            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", GetUsername(), message);
        }

        public async Task Typing()
        {
            await Clients.All.SendAsync("IsTyping", $"{GetUsername()} is typing...");
        }


    }
