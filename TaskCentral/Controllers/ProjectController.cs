using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskCentral.Application.DTOs.Response;
using TaskCentral.Application.Interfaces;

namespace TaskCentral.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpGet]
        public async Task <IActionResult> GetAll(ProjectResponseDto dto)
        {
            var projects = await _projectService.GetAllProjectAsync();

            if (projects == null)
                return NotFound();

            return Ok(projects);
        }

        
    }
}
