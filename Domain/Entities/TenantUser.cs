using TaskFlow.Domain.Common;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Entities
{
    public class TenantUser : BaseEntity
    {
        public string UserId { get; set; } = string.Empty;
        public AppUser User { get; set; } = null!;
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; } = null!;
        public TenantRole Role { get; set; }
    }
}