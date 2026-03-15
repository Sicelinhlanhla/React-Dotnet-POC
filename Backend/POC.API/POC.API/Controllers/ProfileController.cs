using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POC.API.Services;
using System.Security.Claims;

namespace POC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private IUserService _service;

        public ProfileController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("myProfile")]
        public async Task<IActionResult> Get()
        { 
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized();
            }

            var userDetails = await _service.GetUserById(Guid.Parse(userId));

            if (userDetails == null)
            {
                return NotFound();
            }

            return Ok(userDetails);

        }
    }
}
