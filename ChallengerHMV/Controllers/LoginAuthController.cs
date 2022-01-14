using ChallengerHMV.Domain.Authentication;
using ChallengerHMV.Services.AuthenticationService.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ChallengerHMV.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class LoginAuthController : ControllerBase
    {
        private readonly ILogger<LoginAuthController> _logger;
        private readonly IAuthService _authService;

        public LoginAuthController(ILogger<LoginAuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpPost(Name = "Login")]
        public async Task<IActionResult> LoginAuth(AuthUser user)
        {
            var loginUser = await _authService.LoginUser(user);
            if (string.IsNullOrEmpty(loginUser))
                return Unauthorized();
            else
                return Ok(loginUser);
        }
    }
}