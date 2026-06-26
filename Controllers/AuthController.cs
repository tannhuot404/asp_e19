using api_demo_e19.DTO;
using api_demo_e19.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_demo_e19.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController(IUserService _userService) : ControllerBase
    {

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRequestDTO userDTO)
        {
            var result = await _userService.Register(userDTO);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserRequestDTO userDto)
        {
            var result = await _userService.Login(userDto);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
