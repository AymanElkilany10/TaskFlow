using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities
{
    public class Notification : BaseEntity
    {
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; } = null!;
        public string ReceiverId { get; set; } = string.Empty;
        public AppUser Receiver { get; set; } = null!;
        public string Content { get; set; } = string.Empty;
        public bool IsRead { get; set; } = false;
    }
}