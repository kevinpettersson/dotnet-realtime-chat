using dotnet_realtime_chat.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_realtime_chat.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {

        private readonly ChatHub _chatHub;

        public ChatController(ChatHub chatHub)
        {
            _chatHub = chatHub;
        }

        [HttpGet("me")]
        public IActionResult Me()
        {
            return Ok(new
            {
                IsAuthenticated = User.Identity?.IsAuthenticated,
                Name = User.Identity?.Name,
                Claims = User.Claims.Select(c => new { c.Type, c.Value })
            });
        }

        [HttpPost("send")]
        public async Task SendMessage(String message)
        {
            var user = User.Identity?.Name;

            return await _chatHub.SendMessage(user, message);
            
        }

    }
}