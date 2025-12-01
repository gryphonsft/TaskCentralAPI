using TaskCentral.Application.DTOs.Request;
using TaskCentral.Application.DTOs.Response;
using TaskCentral.Domain.Entities;
using TaskCentral.Domain.Interfaces;

namespace TaskCentral.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<TaskResponseDto>> GetAllTasksAsync()
        {
            var tasks = await _taskRepository.GetAllAsync();

            var response = tasks.Select(t => new TaskResponseDto
            {
                Id = t.Id,
                ProjectName = t.Project.Title,
                Description = t.Description,
                CreatedAt = t.CreatedAt,
                DueDate = t.DueDate,
                Status = t.Status,
                Priority = t.Priority,

                Assignedusernames = t.TaskAssignments
                    .Select(ta => ta.AppUser.UserName ?? "")
                    .ToList()
            });
            return response;
        }

        public async Task<int> CreateTaskAsync(TaskCreateDto dto)
        {
            var task = new Tasks
            {
                ProjectId = dto.ProjectId,
                Description = dto.Description,
                Priority = dto.Priority,
                DueDate = dto.DueDate,
                CreatedAt = DateTime.UtcNow,
                Status = Status.Bosta
            };

            await _taskRepository.AddAsync(task);

            return task.Id;
        }
    }
}