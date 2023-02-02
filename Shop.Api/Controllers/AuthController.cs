using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Infrastructue.Abstracts;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Auth")]
        public async Task<IActionResult> Auth([FromForm] string username, string password)
        {
            var token = await _authService.Login(username, password);
            return Ok(token);
        }
    }
}
