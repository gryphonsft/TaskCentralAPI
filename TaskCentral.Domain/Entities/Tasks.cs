using TaskCentral.Domain.User;

namespace TaskCentral.Domain.Entities
{
    public sealed class Tasks
    {
        public int Id { get; set; }

        //Hangi Proje'ye bağlı
        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;

        public string Description { get; set; } = string.Empty;

        //Kimlere atanmış
        public ICollection<TaskAssignment> TaskAssignments { get; set; } = new List<TaskAssignment>();
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueDate { get; set; }
    }

    public enum Status
    {
        Bosta,
        YapimAsamasi,
        Sonlandi
    }
    public enum Priority
    {
        Dusuk,
        Orta,
        Yuksek
    }
}
