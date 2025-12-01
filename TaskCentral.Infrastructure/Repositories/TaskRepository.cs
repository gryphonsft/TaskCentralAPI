using Microsoft.EntityFrameworkCore;
using TaskCentral.Domain.Entities;
using TaskCentral.Infrastructure.Data;

namespace TaskCentral.Infrastructure.Repositories
{
    public class TaskRepository 
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tasks>> GetAllAsync() => await _context.Tasks.ToListAsync();

        public async Task<Tasks?> GetByIdAsync(int id)
        {
            return await _context.Tasks.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddAsync(Tasks tasks)
        {
            await _context.Tasks.AddAsync(tasks);
        }

    }
}
