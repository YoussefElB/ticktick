namespace TickTick.Models
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
    }
    public class BaseAuditableEntity : BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
