using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskCentral.Domain.Entities;

namespace TaskCentral.Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Tasks>> GetAllAsync();
        Task<Tasks?> GetByIdAsync(int id);
        Task AddAsync(Tasks tasks);
    }
}
