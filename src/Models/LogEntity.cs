namespace Models
{
    public class LogEntity : BaseEntity<Guid>
    {
        public string ServiceName { get; set; }
        public int DataSize { get; set; }
        public long ElapsedTimeMs { get; set; }
    }
}
