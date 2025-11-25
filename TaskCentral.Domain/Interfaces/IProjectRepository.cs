using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskCentral.Domain.Entities;

namespace TaskCentral.Domain.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllAsync();
        Task<Project?> GetByIdAsync(int id);
        Task AddAsync(Project project);
        Task UpdateAsync(Project project);
        Task DeleteByIdAsync(int id);
        Task<IEnumerable<Project>> FindAsync(Expression<Func<Project, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<Project, bool>> predicate);
        Task SaveChangesAsync();
    }
}
