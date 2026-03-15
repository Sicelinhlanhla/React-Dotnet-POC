using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POC.API.Dtos;
using POC.API.Infrastructure.Data;
using POC.API.Services;

namespace POC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerUser)
        {
            await _userService.RegisterUser(registerUser);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginUser)
        { 
            var result = await _userService.LoginUser(loginUser);
             if(result == null) 
                return Unauthorized();
             else return Ok(new { message = result});
        }
    }
}
