using Microsoft.EntityFrameworkCore;
using TaskCentral.Domain.Entities;
using TaskCentral.Domain.Interfaces;
using TaskCentral.Infrastructure.Data;

namespace TaskCentral.Infrastructure.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly ApplicationDbContext _context;

        public LogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Logs>> GetAllAsync() => await _context.Logs.ToListAsync();
    }
}