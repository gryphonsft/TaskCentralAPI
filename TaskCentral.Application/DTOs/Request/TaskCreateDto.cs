using TaskCentral.Domain.Entities;

namespace TaskCentral.Application.DTOs.Request
{
    public class TaskCreateDto
    {
        public int ProjectId { get; set; }
        public string Description { get; set; } = string.Empty;
        public Priority Priority { get; set; }
        public DateTime DueDate { get; set; }
    }
}