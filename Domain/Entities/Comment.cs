using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities
{
    public class Comment : SoftDeletableEntity
    {
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; } = null!;
        public Guid TaskId { get; set; }
        public Task Task { get; set; } = null!;
        public string? UserId { get; set; } = string.Empty;
        public AppUser User { get; set; } = null!;
        public string Content { get; set; } = string.Empty;
    }
}