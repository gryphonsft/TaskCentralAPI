using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskCentral.Domain.Entities;

namespace TaskCentral.Application.DTOs.Response
{
    public class TaskResponseDto
    {
        public int Id { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> Assignedusernames { get; set; } = new();
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueDate { get; set; }
    }
}
