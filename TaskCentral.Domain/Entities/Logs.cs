namespace TaskCentral.Domain.Entities
{
    public class Logs
    {
        public int Id { get; set; }
        public string Action { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public AppLogLevel Level { get; set; } = AppLogLevel.Bilgi;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
    public enum AppLogLevel
    {
        Bilgi,
        Uyarı,
        Hata
    }
}