using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities
{
    public class Workspace : SoftDeletableEntity
    {
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; } = null!;
        public string CreatedByUserId { get; set; } = string.Empty;
        public AppUser CreatedBy { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}