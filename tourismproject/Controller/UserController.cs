using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tourismproject.Dto;
using tourismproject.repository;
using tourismproject.Service;

namespace tourismproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserSrvice _userSrvice;

        public UserController(IUserSrvice userSrvice)
        {
            _userSrvice = userSrvice;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var success = await _userSrvice.RegisterAsync(dto);
            if (!success)
                return BadRequest("UserName is allready taken.");
            return Ok("User registered successfully.");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _userSrvice.LoginAsync(dto);
            if (user == null) return Unauthorized("Invalid username or password");
            return Ok(new { massage = "Login successfully." });
        }
    }

    public interface IUserService
    {
    }
}
