using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.App.Abstracts;
using Shop.App.Moduls;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CreateUser user)
        {
            await _userService.CreateAsync(user);
            return Ok(user);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            return Ok(await _userService.GetUserAsync(id));
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _userService.GetAllAsync());
        }

    }
}
