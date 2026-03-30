using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities
{
    public class TaskAssignee : BaseEntity
    {
        public Guid TaskId { get; set; }
        public Task Task { get; set; } = null!;
        public string UserId { get; set; } = string.Empty;
        public AppUser User { get; set; } = null!;
    }
}