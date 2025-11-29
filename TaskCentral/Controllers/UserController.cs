using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskCentral.Application.Interfaces;

namespace TaskCentral.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        private readonly IRoleAssignService _roleAssignService;

        public UserController(IRoleAssignService roleAssignService)
        {
            _roleAssignService = roleAssignService;
        }
        [HttpGet]
        public async Task<IList<string>> GetUserRoles(Guid userId)
        {
            var result = await _roleAssignService.GetUserRolesAsync(userId);

            return result;
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(Guid userId,string roleName)
        {
            var result = await _roleAssignService.AssignRoleToUserAsync(userId,roleName);

            if(!result)
            return BadRequest("Rol atanamadı");

            return Ok("Rol basariyla atandi");
        }
    }
}