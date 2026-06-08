using Microsoft.AspNetCore.Mvc;
using dotnet_realtime_chat.DTOs;

namespace dotnet_realtime_chat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            _logger.LogInformation("User registering: {Username}", request.Username);

            return Ok("User registered (dummy response)");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            _logger.LogInformation("User logging in: {Username}", request.Username);

            return Ok("Login sucessful (dummy response)");
        }



        
    }
}