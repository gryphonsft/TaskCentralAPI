using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskCentral.Domain.Entities;
using TaskCentral.Domain.Interfaces;
using TaskCentral.Infrastructure.Data;

namespace TaskCentral.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Project>> GetAllAsync() => await _context.Project.ToListAsync();
        public async Task<Project?> GetByIdAsync(int id)
        {
            return await _context.Project.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddAsync(Project project)
        {
            await _context.Project.AddAsync(project);
        }
        public async Task UpdateAsync(Project project)
        {
            _context.Project.Update(project);
        }
        public async Task DeleteByIdAsync(int id)
        {
            var project = await GetByIdAsync(id);
            if(project != null)
            {
                _context.Project.Remove(project);
            }
        }
        public async Task<IEnumerable<Project>> FindAsync(Expression<Func<Project, bool>> predicate)
        {
            return await _context.Project
                .Where(predicate)
                .ToListAsync();
        }
        public async Task<bool> AnyAsync(Expression <Func<Project, bool>> predicate)
        {
            return await _context.Project.AnyAsync(predicate);
        }
        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}