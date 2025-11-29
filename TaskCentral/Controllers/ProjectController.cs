using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskCentral.Application.DTOs.Request;
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
        public async Task<IActionResult> GetAll()
        {
            var projects = await _projectService.GetAllProjectAsync();

            if (projects == null)
                return NotFound();

            return Ok(projects);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);

            return Ok(project);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProjectCreateDto dto) 
        {
            await _projectService.CreateProjectAsync(dto);
            return Ok("Proje eklendi.");
        }
        [HttpGet]
        public async Task<IActionResult> Search(string keyvalue)
        {
            var result = await _projectService.SearchProjectAsync(keyvalue);

            if (!result.Any())
                return NoContent();

            return Ok(result);
        }
    }
}
