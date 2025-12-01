using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskCentral.Domain.User;

namespace TaskCentral.Domain.Entities
{
    public class TaskAssignment
    {
        public int TaskId { get; set; }
        public Task Task { get; set; } = null!;

        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; } = null!;
    }
}
