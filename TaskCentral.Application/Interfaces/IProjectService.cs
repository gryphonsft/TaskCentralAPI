using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskCentral.Application.DTOs.Request;
using TaskCentral.Application.DTOs.Response;

namespace TaskCentral.Application.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectResponseDto>> GetAllProjectAsync();
        Task<ProjectResponseDto?> GetProjectByIdAsync(int id);
        Task CreateProjectAsync(ProjectCreateDto projectrequest);
    }
}
