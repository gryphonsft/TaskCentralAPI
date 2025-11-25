using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskCentral.Application.DTOs.Response;
using TaskCentral.Application.Interfaces;
using TaskCentral.Domain.Entities;
using TaskCentral.Domain.Interfaces;

namespace TaskCentral.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<ProjectResponseDto>> GetAllProjectAsync()
        {
            var projects = await _projectRepository.GetAllAsync();

            var response = projects.Select(p => new ProjectResponseDto
            {
                Title = p.Title,
                Description = p.Description,
                CreatedAt = p.CreatedAt,
                DueDate = p.DueDate

            }).ToList();
            return response;
        }
    }
}
