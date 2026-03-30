using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities
{
    public class Column : SoftDeletableEntity
    {
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; } = null!;
        public Guid BoardId { get; set; }
        public Board Board { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public int Position { get; set; }
        public ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}