using TaskFlow.Domain.Common;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Entities
{
    public class ActivityLog : BaseEntity
    {
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; } = null!;
        public string? UserId { get; set; }
        public AppUser User { get; set; } = null!;
        public ActionType ActionType { get; set; }
        public string EntityType { get; set; } = string.Empty;
        public Guid EntityId { get; set; }
    }
}