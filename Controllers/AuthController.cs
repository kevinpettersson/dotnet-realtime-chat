using Microsoft.AspNetCore.Mvc;
using dotnet_realtime_chat.DTOs;
using Microsoft.AspNetCore.Identity;

namespace dotnet_realtime_chat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(
            ILogger<AuthController> logger, 
            UserManager<User> userManager, 
            SignInManager<User> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            _logger.LogInformation("User registering: {Username}", request.Username);

            var user = new User 
            { 
                UserName = request.Username,
                CreatedAt = DateTime.UtcNow
            };
        
            // Registers the user in the database
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("User registered");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            _logger.LogInformation(
                "User logging in: {Username}",
                request.Username);
            
             var result = await _signInManager.PasswordSignInAsync(
                request.Username,
                request.Password,
                isPersistent: false,
                lockoutOnFailure: false
            );

            if (!result.Succeeded)
            {
                return Unauthorized("Invalid username or password");
            }

            return Ok("Login successful");
        }
    }
}