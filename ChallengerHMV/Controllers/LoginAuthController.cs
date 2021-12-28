using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChallengerHMV.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class LoginAuthController : ControllerBase
    {
        private readonly ILogger<LoginAuthController> _logger;

        public LoginAuthController(ILogger<LoginAuthController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "AuthLogin")]
        public async Task<IActionResult> PostAuth()
        {
            return null;
        }
    }
}