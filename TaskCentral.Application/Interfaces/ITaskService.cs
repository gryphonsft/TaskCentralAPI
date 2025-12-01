using TaskCentral.Application.DTOs.Request;
using TaskCentral.Application.DTOs.Response;

namespace TaskCentral.Application.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskResponseDto>> GetAllTasksAsync();
        Task<int> CreateTaskAsync(TaskCreateDto dto);
    }
}