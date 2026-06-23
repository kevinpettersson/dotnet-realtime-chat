using dotnet_realtime_chat.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace dotnet_realtime_chat.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {

        private readonly IMessageService _messageService;

        public ChatController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("history")]
        public async Task<IActionResult> History()
        {
            var messages = await _messageService.GetHistoryAsync();

            return Ok(messages);
        }

    }
}