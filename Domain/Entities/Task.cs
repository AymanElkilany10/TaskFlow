using TaskFlow.Domain.Common;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Entities
{
    public class Task : SoftDeletableEntity
    {
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; } = null!;
        public Guid ColumnId { get; set; }
        public Column Column { get; set; } = null!;
        public string CreatedByUserId { get; set; } = string.Empty;
        public AppUser CreatedBy { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Position { get; set; }
        public Priority Priority { get; set; }
        public DateTime? Deadline { get; set; }
        public ICollection<TaskAssignee> TaskAssignees { get; set; } = new List<TaskAssignee>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}