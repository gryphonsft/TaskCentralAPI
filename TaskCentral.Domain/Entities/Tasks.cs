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

        //Kime atanmış
        public int AssignedTo { get; set; }
        public AppUser AppUser { get; set; } = null!;

        public TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueDate { get; set; }
    }

    public enum TaskStatus
    {
        Bosta,
        YapimAsamasi,
        Sonlandi
    }
    public enum TaskPriority
    {
        Dusuk,
        Orta,
        Yuksek
    }
}
