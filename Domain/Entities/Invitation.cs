using TaskFlow.Domain.Common;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Entities
{
    public class Invitation : BaseEntity
    {
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; } = null!;
        public string InvitedByUserId { get; set; } = string.Empty;
        public AppUser InvitedBy { get; set; } = null!;
        public string InvitedEmail { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public InvitationStatus Status { get; set; } = InvitationStatus.Pending;
    }
}