using Microsoft.AspNetCore.Mvc;
using dotnet_realtime_chat.DTOs;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Azure.Identity;
using Microsoft.AspNetCore.Identity;

namespace dotnet_realtime_chat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly AppDbContext _context;

        public AuthController(ILogger<AuthController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            _logger.LogInformation("User registering: {Username}", request.Username);
            /*
            var user = new User
            {
                Name = request.Username,
                Password = request.Password
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            */

            return Ok("User registered");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            _logger.LogInformation(
                "User logging in: {Username}",
                request.Username);
            /*
            var user = _context.Users
                .FirstOrDefault(u => u.Name == request.Username);

            if (user == null)
            {
                return BadRequest("Invalid username or password");
            }

            if (user.Password != request.Password)
            {
                return BadRequest("Invalid username or password");
            }
            */
            return Ok("Login successful");
        }
    }
}