using eShopSolution.Application.System.User;
using eShopSolution.ViewModels.System.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromForm] LoginRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Token = await _userService.Authenticate(request);
            if (string.IsNullOrEmpty(Token))
            {
                return BadRequest("Username or password is incorrect.");
            }
            return Ok(new {token = Token});
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterRequest request)
        {
            var result = await _userService.Register(request);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
