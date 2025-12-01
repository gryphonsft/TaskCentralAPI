using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskCentral.Application.DTOs.Request;
using TaskCentral.Application.Interfaces;

namespace TaskCentral.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task <IActionResult> Login([FromBody] LoginUserDto dto)
        {
            var result = await _authService.LoginAsync(dto);

            if(!result.Success)
                return BadRequest(result.Message);

            return Ok(new
            {
                jwt = result.Token,
                message = result.Message
            });
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            var (success, message) = await _authService.RegisterAsync(dto); 

            if (!success)
                return Unauthorized(message);

            return Ok(new { message });
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _authService.GetAllUserDetailsAsync();
            return Ok(result);
        }
    }
}
