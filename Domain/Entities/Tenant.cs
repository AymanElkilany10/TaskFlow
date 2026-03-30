using Microsoft.EntityFrameworkCore.Metadata;
using TaskFlow.Domain.Common;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Entities
{
    public class Tenant : SoftDeletableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string OwnerId { get; set; } = string.Empty;
        public AppUser Owner { get; set; } = null!;
        public ICollection<TenantUser> TenantUsers { get; set; } = new List<TenantUser>();
        public ICollection<Workspace> Workspaces { get; set; } = new List<Workspace>();
        public ICollection<Invitation> Invitations { get; set; } = new List<Invitation>();
    }
}