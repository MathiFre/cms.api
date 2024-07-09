namespace CMS.Domain.Common
{
    public class AuditEntity : BaseEntity
    {
        public AuditEntity()
        {
            CreatedAt = DateTime.Now;
        }

        public string CreatedBy { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; } = default!;
        public DateTime? UpdatedAt { get; set; } = default!;
    }
}
