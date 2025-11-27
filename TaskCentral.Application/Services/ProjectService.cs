using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskCentral.Application.DTOs.Request;
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

        public async Task<ProjectResponseDto?> GetProjectByIdAsync(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);

            if (project == null)
                return null;

            return new ProjectResponseDto
            {
                Title = project.Title,
                Description = project.Description,
                CreatedAt = project.CreatedAt,
                DueDate = project.DueDate
            };
        }
        public async Task CreateProjectAsync(ProjectCreateDto projectrequest)
        {
            var project = new Project
            {
                Title = projectrequest.Title,
                Description = projectrequest.Description,
                DueDate = projectrequest.DueDate
            };

            await _projectRepository.AddAsync(project);
            await _projectRepository.SaveChangesAsync();
        }
        public async Task<IEnumerable<ProjectResponseDto>> SearchProjectAsync(string keyvalue)
        {
            if (string.IsNullOrEmpty(keyvalue) || keyvalue.Length <= 3)
            {
                return Enumerable.Empty<ProjectResponseDto>();
            }

            var projects = await _projectRepository.FindAsync(
                p => p.Title.ToLower().Contains(keyvalue) ||
                p.Description.ToLower().Contains(keyvalue));

            return projects.Select(p => new ProjectResponseDto
            { 
            Title = p.Title,
            Description = p.Description
            });
        }
    }
}
