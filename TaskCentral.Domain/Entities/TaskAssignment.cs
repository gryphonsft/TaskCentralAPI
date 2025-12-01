using TaskCentral.Domain.User;

namespace TaskCentral.Domain.Entities
{
    public class TaskAssignment
    {
        public int TaskId { get; set; }
        public Tasks Tasks { get; set; } = null!;

        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; } = null!;
    }
}
