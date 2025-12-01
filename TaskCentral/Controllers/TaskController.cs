using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskCentral.Application.DTOs.Request;
using TaskCentral.Application.Services;

namespace TaskCentral.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskService.GetAllTasksAsync();

            if (tasks == null)
                return NotFound();

            return Ok(tasks);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]TaskCreateDto dto)
        {
            await _taskService.CreateTaskAsync(dto);
            return Ok("Task basariyla olusturuldu");
            //Service tarafında saveChangesAsync kullanıp kullanmayacagımı arastır
        }
    }
}