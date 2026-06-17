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
        private readonly IJwtTokenService _tokenService;

        public AuthController(
            ILogger<AuthController> logger, 
            UserManager<User> userManager, 
            SignInManager<User> signInManager,
            IJwtTokenService tokenService)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
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
            _logger.LogInformation("User logging in: {Username}", request.Username);
            
            // find the user in the databse
            var user = await _userManager.FindByNameAsync(request.Username);

            if (user == null)
                return Unauthorized("Invalid username or password");

            // verify the given password in the database
            var passwordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!passwordValid)
                return Unauthorized("Invalid username or password");

            // generate a JWT token for the user
            var token = _tokenService.GenerateToken(user);

            return Ok(new { token });
        }
    }
}